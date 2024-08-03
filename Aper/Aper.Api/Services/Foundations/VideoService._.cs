using Aper.Models.Videos;

namespace Aper.Api.Services.Foundations;

public interface IVideoService
{
  IQueryable<Video> RetrieveAllVideos();
  ValueTask<Video?> RetrieveVideoByIdAsync(string videoId);
  ValueTask<Video> AddVideoAsync(Video video);
  ValueTask<Video> ModifyVideoAsync(Video video);
  //ValueTask<Video> RemoveVideoByIdAsync(Guid videoId);
}
