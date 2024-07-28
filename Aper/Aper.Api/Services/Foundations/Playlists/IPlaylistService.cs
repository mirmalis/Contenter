using Aper.Api.Brokers.TruthBrokers.Models;

namespace Aper.Api.Services.Foundations.Playlists;

public interface IPlaylistService
{
  Task<PlaylistDetails?> Get(string playlistId, bool cacheless = false);
}
