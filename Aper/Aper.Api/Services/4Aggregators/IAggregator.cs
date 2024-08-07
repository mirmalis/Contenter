namespace Aper.Api.Services._4Aggregators;

public interface IAggregator
{
  ValueTask<IEnumerable<object>> GetPlaylistsLatestVideos(string playlistId);
}
