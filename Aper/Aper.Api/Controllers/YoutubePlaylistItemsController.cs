using Microsoft.AspNetCore.Mvc;

namespace Aper.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class YoutubePlaylistItemsController: ControllerBase
{
  #region Constructors
  public YoutubePlaylistsController(IPlaylistService channelService)
  {
    this.playlistService = channelService;
  }
  private  playlistService { get; }
  #endregion
}
