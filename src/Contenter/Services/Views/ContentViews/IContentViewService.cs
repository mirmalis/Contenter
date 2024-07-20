using Contenter.Models.Views.Contents;

namespace Contenter.Services.Views.ContentViews;

public interface IContentViewService
{
  Task<ContentView?> GetContentViewById(Guid id);
  Task<List<ContentView>> GetLatestVideos(int max, int skip = 0);
}
