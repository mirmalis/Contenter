using Contenter.Brokers.Contents;
using Contenter.Brokers.Sources;
using Contenter.Models.Views.Contents;

using Microsoft.EntityFrameworkCore;

namespace Contenter.Services.Views.SourceViews;

public class SourceViewService(ISourceBroker sourceBroker): ISourceViewService
{
  private readonly ISourceBroker sourceBroker = sourceBroker;
  private static readonly System.Linq.Expressions.Expression<Func<Contenter.Models.Sources.Source, SourceView>> core_to_view_expression = item => new SourceView() {
    Id = item.Id,
    Href = item.Href,
    IconPath = item.PlatformId == null ? null : item.Platform!.IconPath,
    PublishedAt = item.PublishedAt,
    Name = item.Name,
    Channel = item.ChannelUid == null ? null : new SourceChannelView() {
      Id = item.Channel!.Id,
      Href = item.Channel!.Href,
      Name = item.Channel!.Title ?? item.Channel!.Name,
    }
  };
  public async Task<List<SourceView>> GetLatest(int max, int skip = 0)
  {
    return await this.sourceBroker.GetListByCreationDate(core_to_view_expression, max, skip);
  }
  public async Task<List<SourceView>> GetChannelSources(Guid channelId, int take, int skip = 0)
  {
    // TODO: bad ?
    return await this.sourceBroker
      .Q
      .Where(item => item.Channel != null && item.Channel.Id == channelId)
      .Select(core_to_view_expression)
      .Skip(skip)
      .Take(take)
      .ToListAsync();
  }
}
