using Aper.Api.Brokers;
using Aper.Models;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class YoutubePlaylistsController: ControllerBase
{
  #region Constructors
  private readonly Database db;
  private readonly IYoutubeApiBroker youtubeApiBroker;
  public YoutubePlaylistsController(Database db, IYoutubeApiBroker broker)
  {
    this.db = db;
    this.youtubeApiBroker = broker;
  }
  #endregion
  [HttpGet]
  public async Task<ActionResult<Aper.Models.Playlist>> CreateOrUpdate(string playlistId)
  {
    try
    {
      var existing = await this.db.Playlists
        .Where(item => item.Id == playlistId)
        .FirstOrDefaultAsync();
      if (existing != null && !existing.IsOld())
        return Ok(existing);
      var data = await this.youtubeApiBroker.GetPlaylistDetails(playlistId);
      if (data == null)
        return NotFound();
      bool isNew = existing == null;
      var now = DateTime.UtcNow.NoMS();
      existing = data.Merge(
        existing,
        channel: await this.db.Channels.FirstOrDefaultAsync(item => item.Id == data.Channel.Id)
             ?? (await this.youtubeApiBroker.GetChannelDetails(data.Channel.Id))?.Merge(null, now)
             ?? throw new Exception("Failed to get a channel for Playlist"),
        now
      );
      if (isNew)
      {
        this.db.Playlists.Add(existing);
      }
      await this.db.SaveChangesAsync();

      return Ok(existing);
    }
    catch (Exception ex)
    {
      return this.BadRequest(ex.Message);
    }
  }
  [HttpGet("Items")]
  public async Task<ActionResult<IEnumerable<object>>> GetItems(string playlistId)
  {
    var existingPL = await this.db.Playlists
      .Include(item => item.PlaylistItems)
      .FirstOrDefaultAsync(item => item.Id == playlistId);
    if (existingPL == null)
    {
      try
      {
        var data = await this.youtubeApiBroker.GetPlaylistDetails(playlistId);
        if(data == null)
        {
          return NotFound();
        }
        var existingChannel = await this.db.Channels
          .FirstOrDefaultAsync(item => item.Id == data.Channel.Id)
          ??
          new Channel() {
            Id = data.Channel.Id,
            Title = data.Channel.Title,
          };
        
        existingPL = data!.Merge(null, existingChannel);
        this.db.Playlists.Add(existingPL);
        await this.db.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    else
    {
      // return from database here
    }

    try
    {
      var results = await this.youtubeApiBroker.Playlist_GetAllVideoIds(playlistId, null);
      var now = DateTime.UtcNow.NoMS();

      var existingPlaylistItemIds = await this.db.PlaylistItems
        .Where(item => results.Select(data => data.Id).Contains(item.Id))
        .Select(item => item.Id)
        .ToListAsync();
      var x1 = results.Where(item => !existingPlaylistItemIds.Contains( item.Id));

      if (!x1.Any())
      {
        return Ok(results);
      }
      var existingVideoIds = await this.db.Videos
        .Where(item => x1.Select(data => data.Video.Id).Contains(item.Id))
        .Select(item => item.Id)
        .ToListAsync();
      var existingChannelIds = await this.db.Channels
        .Where(item => x1.Select(data => data.Video.Channel.Id).Distinct().Contains(item.Id))
        .Select(item => item.Id)
        .ToListAsync();
        ;
      var x2 = x1.Where(item => !existingVideoIds.Contains(item.Video.Id));
      var x3 = x2.Where(item => !existingChannelIds.Contains(item.Video.Channel.Id));

      var corePlaylistItems = x1.Select(data => data.Merge(null, now)).ToList();
      var coreVideos = x2.Select(data => data.Video.Merge(null, now)).ToList();
      var coreChannels = x3.Select(item => item)
        .GroupBy(item => item.Video.Channel.Id)
        .Select(item => item.First())
        .Select(data => data.Video.Channel.Merge(null, now))
        .ToList();
      this.db.PlaylistItems.AddRange(corePlaylistItems);
      this.db.Videos.AddRange(coreVideos);
      this.db.Channels.AddRange(coreChannels);
      await this.db.SaveChangesAsync();
      return Ok(results);
    } catch(Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}
