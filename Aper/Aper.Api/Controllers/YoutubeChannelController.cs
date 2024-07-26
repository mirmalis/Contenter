using Aper.Api.Brokers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Controllers;
[ApiController]
[Microsoft.AspNetCore.Mvc.Route("[controller]")]
public class YoutubeChannelController: ControllerBase
{
  #region Constructors
  private readonly Database db;
  private readonly IYoutubeApiBroker youtubeApiBroker;
  
  public YoutubeChannelController(Database db, IYoutubeApiBroker broker)
  {
    this.db = db;
    this.youtubeApiBroker = broker;
  }
  #endregion
  [HttpPost]
  public async Task<ActionResult<object>> CreateOrUpdateChannelInfo(string channelId)
  {
    try
    {
      var existing = await this.db.Channels.FirstOrDefaultAsync(item => (item.Id == channelId));
      if(existing != null && !existing.IsOld())
        return Ok(existing);
      var data = await this.youtubeApiBroker
        .GetChannelDetails(channelId: channelId);
      if(data == null)
        return NotFound();
      bool isNew = existing == null;
      
      existing = data.Merge(existing);

      if (isNew)
      {
        this.db.Channels.Add(existing);
      }
      await this.db.SaveChangesAsync();
      return this.Ok(existing);
    } catch (Exception ex)
    {
      return this.BadRequest(ex.Message);
    }
  }
  //[HttpGet]
  //public async Task<ActionResult<IEnumerable<object>>> GetChannelUploads(string channelId)
  //{
  //  var channel = await this.db.Channels.FirstOrDefaultAsync();
  //  if(channel == null || channel.UploadsPlaylistId == null)
  //  {
  //    var data = await this.youtubeApiBroker.GetChannelDetails(channelId);
  //    if (data == null)
  //    {
  //      return NotFound($"Channel not found (Id = {channelId})");
  //    }
  //    channel = data.Merge(null);
  //    this.db.Channels.Add(channel);
  //    await this.db.SaveChangesAsync();
  //  }
  //  if(channel.UploadsPlaylistId == null)
  //    throw new Exception("Channel doesnt have uploadsId");
  //}

  //async Task<IActionResult> getNewestNVideosOfChannel(string channelId, int n = 5)
  //{
  //  var now = DateTime.UtcNow;
  //  List<string> parts = [
  //    "snippet",
  //  ];
  //  var existingChannel = await this.db.Channels.FirstOrDefaultAsync(item => item.Id == channelId);
  //  var searchRequest = this.youtubeService.Search.List(string.Join(",", parts));
  //  searchRequest.ChannelId = channelId;
  //  searchRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
  //  searchRequest.MaxResults = n;
  //  if(existingChannel?.ScrapedUntil != null)
  //  {
  //    searchRequest.PublishedAfterDateTimeOffset = new DateTimeOffset(existingChannel.ScrapedUntil.Value, TimeSpan.Zero);
  //  }
  //  var searchResponse = await searchRequest.ExecuteAsync();
  //  var items = searchResponse.Items;
  //  if(existingChannel == null)
  //  {
  //    existingChannel = new Models.Channel() {
  //      Id = channelId,
  //    };
  //    this.db.Add(existingChannel);
  //  }
  //  existingChannel.ScrapedUntil = now;
  //  DateTime? lastVideoPublishedAt = items.Any() ? DateTime.Parse(items.Last().Snippet.PublishedAtRaw) : null;
  //  if(existingChannel.ScrapedSince == null || lastVideoPublishedAt < existingChannel.ScrapedSince)
  //  {
  //    existingChannel.ScrapedSince = lastVideoPublishedAt;
  //  }
  //  var existingVideos = await this.db.Videos.Where(item => items.Select(x => x.Id.VideoId).Contains(item.Id)).ToListAsync();

  //  foreach(var item in items)
  //  {
  //    existingChannel.Title ??= item.Snippet.ChannelTitle;
  //    var existingVideo = existingVideos.FirstOrDefault(video => video.Id == item.Id.VideoId);
  //    if(existingVideo != null)
  //    {
  //      continue;
  //    }
  //    var v = new Models.Video(item, now) {
  //      Author = existingChannel
  //    };
  //    db.Add(v);
  //  }
  //  await this.db.SaveChangesAsync();
  //  return Ok(items);
  //}
}
