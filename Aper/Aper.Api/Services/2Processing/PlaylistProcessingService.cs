using Aper.Api.Services._1Foundations;
using Aper.Models.Playlists;

namespace Aper.Api.Services._2Processing;

public partial class PlaylistProcessingService(IPlaylistService playlistService):
  AbstractProcessingService<Playlist, string, IPlaylistService>(playlistService),
  IPlaylistProcessingService
{
  
}
