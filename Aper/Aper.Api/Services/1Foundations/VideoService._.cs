using Aper.Models.Videos;

namespace Aper.Api.Services._1Foundations;

public interface IVideoService: IAbstractFoundationService<Video, string>
{
  ValueTask<IEnumerable<Video>> GetVideoByPlaylistIdAsync(string playlistId);
  ValueTask<Video?> GetVideoByIdAsync(string videoId);
}
