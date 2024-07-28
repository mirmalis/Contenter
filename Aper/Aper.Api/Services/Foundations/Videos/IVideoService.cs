using Aper.Api.Brokers.YoutubeApiBrokers.Models;
namespace Aper.Api.Services.Foundations.Videos;

public interface IVideoService
{
  Task<VideoDetails?> Get(string videoId, bool cacheless = false);
}
