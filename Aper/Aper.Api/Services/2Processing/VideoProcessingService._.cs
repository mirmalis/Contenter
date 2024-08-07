using Aper.Models.Videos;

namespace Aper.Api.Services._2Processing;

public interface IVideoProcessingService: IAbstractProcessingService<Video, string>
{
  ValueTask<IEnumerable<Video>> GetExistingVideosByPlaylistIdAsync(string playlistId);
}
