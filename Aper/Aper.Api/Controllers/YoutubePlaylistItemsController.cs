//using Aper.Api.Services.Foundations;

//using Microsoft.AspNetCore.Mvc;

//namespace Aper.Api.Controllers;
//[ApiController]
//[Route("[controller]")]
//public class YoutubePlaylistItemsController(IPlaylistItemService playlistService): ControllerBase
//{
//  private readonly IPlaylistItemService playlistService = playlistService;

//  [HttpPost]
//  public async ValueTask<ActionResult<IEnumerable<Aper.Models.PlaylistItems.PlaylistItem>>> PostPlaylistItems(string playlistId)
//  {
//    var xs = await playlistService.ScrapePlaylist(playlistId);
//    return Ok(xs);
//  }
//}
