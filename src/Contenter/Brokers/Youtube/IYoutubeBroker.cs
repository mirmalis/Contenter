using Contenter.Models.Views;

namespace Contenter.Brokers.Youtube;

public interface IYoutubeBroker
{
  Task<YoutubeVideo?> GetVideoInfo(string identifier);
  Task<IEnumerable<Models.PlaylistItem>?> GetAllChannelVideos(string channelId);
}
