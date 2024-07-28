using Aper.Api.Controllers.Models.Videos;
using Aper.Api.Services.Foundations.Videos;

using Microsoft.AspNetCore.Mvc;

namespace Aper.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class YoutubeVideoController: ControllerBase
{
  #region Constructors
  private readonly IVideoService videoService;
  public YoutubeVideoController(IVideoService videoService)
  {
    this.videoService = videoService;
  }
  #endregion
  [HttpGet]
  public async Task<ActionResult<OutVideoDetails>> GetDetails(string videoId)
  {
    var details = await this.videoService.Get(videoId);
    if (details == null)
      return NotFound(null);
    return Ok(
      new OutVideoDetails() {
        Id = details.Id,
        Title = details.Title,
        PublishedAt = details.PublishedAt,
        Channel = new() {
          Id = details.Channel.Id,
          Title = details.Channel.Title,
        }
      }
    );
  }
}
