using Aper.Api.Services._4Aggregators;

using Microsoft.AspNetCore.Mvc;

namespace Aper.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaylistVideosController: RESTFulSense.Controllers.RESTFulController
{
  public PlaylistVideosController(ITopPlaylistFunctions aggr)
  {
    this.Aggr = aggr;
  }
  public ITopPlaylistFunctions Aggr { get; }

  [HttpGet()]
  public async Task<ActionResult<IEnumerable<object>>> GetVideos(string playlistId)
  {
    var result = await this.Aggr.GetPlaylistsLatestVideos(playlistId);
    if(result == null)
      return BadRequest("Playlist doesn't exist");
    return Ok(result);
  }

  [HttpPost]
  public async Task<ActionResult<IEnumerable<object>>> GetVideosUntill(string playlistId, DateTimeOffset until)
  {
    var result = await this.Aggr.UpdatePlaylistUntil(playlistId, until);
    if (result == null)
      return BadRequest("Playlist doesn't exist");
    return Ok(result);
  }
}
