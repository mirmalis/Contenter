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
      Sources = content.SourceAssignments.OrderBy(item => item.Index).Select(ass => new SourceView() {
        Href = ass.Source.Href,
        Name = ass.Source.DefinitionUid ?? null,
        IconPath = ass.Source.PlatformId == null ? null : ass.Source.Platform!.IconPath,
      }),
      Guests = content.GuestPersonaAssignments.Select(ass => new PersonaView() {
        Id = ass.GuestId,
        Name = ass.Guest.Name,
        Image = null,
      })
    };

  public async Task<List<ContentView>> GetLatestVideos(int max, int skip = 0)
  {
    return await this.contentBroker.GetLatestContents(core_to_view_expression, max: max, skip: skip);
  }
}
