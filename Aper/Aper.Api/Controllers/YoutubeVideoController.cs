using Aper.Api.Services._4Aggregators;

using Microsoft.AspNetCore.Mvc;

using RESTFulSense.Controllers;

namespace Aper.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class YoutubeVideoController: RESTFulController
{
  #region Constructors
  public YoutubeVideoController(IVideoAggregator videoService) : base()
  {
    this.videoOrchestrator = videoService;
  }
  private IVideoAggregator videoOrchestrator { get; }
  #endregion
  [HttpGet]
  public async Task<ActionResult<object?>> GetVideoAsync(string videoId)
  {
    try
    {
      var existing = await this.videoOrchestrator.GetVideo(videoId);
      return existing;
    } catch (Exception ex)
    {
      return BadRequest(ex);
    }
  }
}
