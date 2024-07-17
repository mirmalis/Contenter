using Contenter.Models.Views;

namespace Contenter.Services.Views.Youtube;

public interface IYoutubeBroker
{
  Task<YoutubeVideo?> GetVideoInfo(string identifier);
}
