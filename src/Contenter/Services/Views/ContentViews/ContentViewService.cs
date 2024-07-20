using Contenter.Brokers.Contents;
using Contenter.Models.Views.Contents;

namespace Contenter.Services.Views.ContentViews;

public class ContentViewService(IContentBroker contentBroker): IContentViewService
{
  private readonly IContentBroker contentBroker = contentBroker;
  private static readonly System.Linq.Expressions.Expression<Func<Contenter.Models.Contents.Content, ContentView>> core_to_view_expression = 
    content => new ContentView() {
      Id = content.Id,
      Name = content.Name,
      Fam = content.FamId == null ? null : new ContentFamView() {
        Id = content.FamId!.Value,
        Name = content.Fam!.Name,
      },

      Sources = content.Sources.Select(source => new SourceView() {
        Id = source.Id,
        PublishedAt = source.PublishedAt,
        Href = source.Href,
        Name = source.DefinitionUid ?? null,
        IconPath = source.PlatformId == null ? null : source.Platform!.IconPath,
        Channel = source.ChannelUid == null ? null : new SourceChannelView {
          Id = source.Channel!.Id,
          Href = $"https://www.youtube.com/channel/{source.Channel!.Uid}",
          Name = source.Channel!.Title ?? source.Channel!.Name,
        }
      }),
      Guests = content.GuestPersonaAssignments.Select(ass => new PersonaView() {
        Id = ass.GuestId,
        Name = ass.Guest.Name,
        Image = null,
      })
    };

  public async Task<List<ContentView>> GetLatestVideos(int max, int skip = 0)
  {
    return await this.contentBroker.GetLatestContentsSelection(core_to_view_expression, max: max, skip: skip);
  }

  public async Task<ContentView?> GetContentViewById(Guid id)
  {
    return await this.contentBroker.GetContentsByIdSelection(core_to_view_expression, id);
  }
}
