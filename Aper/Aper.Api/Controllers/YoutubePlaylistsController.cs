using Aper.Api.Brokers.TruthBrokers.Models;
using Aper.Api.Controllers.Models.Playlists;
using Aper.Api.Services.Foundations.Playlists;

using Microsoft.AspNetCore.Mvc;

namespace Aper.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class YoutubePlaylistsController: ControllerBase
{
  #region Constructors
  public YoutubePlaylistsController(IPlaylistService channelService)
  {
    this.playlistService = channelService;
  }
  private IPlaylistService playlistService { get; }
  #endregion

  [HttpGet]
  public async Task<ActionResult<OutPlaylistDetails>> GetDetails(string playlistId)
  {
    var details = await this.playlistService.Get(playlistId);
    if (details == null)
      return NotFound(null);
    return Ok(
      new OutPlaylistDetails() {
        Id = details.Id,
        Channel = new() {
          Id = details.Channel.Id,
          Title = details.Channel.Title,
        },
        CurrentItemsCount = details.CurrentItemsCount,
        PublishedAt = details.PublishedAt,
        Title = details.Title,
        Accessibility = details.PrivacyStatus == null ? null : new (){
          IsReachable = details.PrivacyStatus.Value.HasFlag(PrivacyStatuses._unlisted),
          IsListed = details.PrivacyStatus.Value.HasFlag(PrivacyStatuses._public),
        }
      }
    );
  }

}
