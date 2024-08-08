using Aper.Api.Services._1Foundations;
using Aper.Models.PlaylistItems;

namespace Aper.Api.Services._2Processing;

public class PlaylistItemsProcessingService(IPlaylistItemsService playlistService):
  AbstractProcessingService<PlaylistItem, string, IPlaylistItemsService>(playlistService),
  IPlaylistItemsProcessingService
{
}
