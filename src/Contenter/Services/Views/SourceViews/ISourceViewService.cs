using Contenter.Models.Views.Contents;

namespace Contenter.Services.Views.SourceViews;

public interface ISourceViewService
{
  Task<List<SourceView>> GetChannelSources(Guid channelId, int max, int skip = 0);
  Task<List<SourceView>> GetLatest(int max, int skip = 0);
}
