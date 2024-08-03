using Aper.Models.Videos;

namespace Aper.Api.Services.Foundations;

public partial class VideoService: AbstractFoundryService<Video, string>, IVideoService
{
  public IQueryable<Video> RetrieveAllVideos() => this.storageBroker.SelectAllVideos();
  public async ValueTask<Video?> RetrieveVideoByIdAsync(string id) => await this.storageBroker.SelectVideoByIdAsync(id);
  public async ValueTask<Video> AddVideoAsync(Video video) => await this.standardAddAsync(video);
  public async ValueTask<Video> ModifyVideoAsync(Video video) => await this.standardModifyAsync(video);
}
