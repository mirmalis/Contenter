using Contenter.Models.Views.Contents;

namespace Contenter.Services.Views.ContentViews;

public interface IContentViewService
{
  Task<List<ContentView>> GetLatestVideos(int max, int skip = 0);
}
