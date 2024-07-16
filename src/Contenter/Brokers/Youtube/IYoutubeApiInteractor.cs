
namespace Contenter.Brokers.Youtube;

public interface IYoutubeApiInteractor
{
  Task<VideoModel?> GetVideoInfo(string identifier);
}
