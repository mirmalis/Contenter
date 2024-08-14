using Aper.Api.Services._4Aggregators;

using Microsoft.AspNetCore.Mvc;

using RESTFulSense.Controllers;

namespace Aper.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class ChannelVideosController: RESTFulController
{
  #region Constructors
  ITopChannelFunctions channelFunctions { get; }
  public ChannelVideosController(ITopChannelFunctions topChannelFunctions)
  {
    this.channelFunctions = topChannelFunctions;
  }
  #endregion
  [HttpGet]
  public async ValueTask<ActionResult<IEnumerable<object>>> GetChannelVideos(string channelId)
  {
    var videos = await this.channelFunctions.GetChannelsLatestVideos(channelId);
    if(videos is null)
      return NotFound();
    return Ok(videos);
  }
}
