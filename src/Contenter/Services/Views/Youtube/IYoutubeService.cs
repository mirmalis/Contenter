using Contenter.Models.Views;

namespace Contenter.Services.Views.Youtube;

public interface IYoutubeService
{
  Task<YoutubeVideo?> GetVideoInfo(string identifier);
}
