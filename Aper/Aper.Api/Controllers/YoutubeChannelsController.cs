using Aper.Api.Brokers.YoutubeApiBrokers.Models;
using Aper.Api.Controllers.Models.Channels;
using Aper.Api.Services.Foundations.Channels;

using Microsoft.AspNetCore.Mvc;

namespace Aper.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class YoutubeChannelsController: ControllerBase
{
  #region Constructors
  public YoutubeChannelsController(IChannelService channelService)
  {
    this.ChannelService = channelService;
  }
  private IChannelService ChannelService { get; }
  #endregion
  [HttpGet]
  public async Task<ActionResult<OutChannelDetails?>> GetDetails(string channelId)
  {
    ChannelDetails? details = await this.ChannelService.Get(channelId);
    if (details == null)
      return NotFound(null);
    return Ok(
      new OutChannelDetails() {
        Id = details.Id,
        Handle = details.Handle,
        Title = details.Title,
        PublishedAt = details.PublishedAt,
        Country = details.Country,
        UploadsPlaylist = details.UploadsPlaylist,
      }
    );
  }
}
