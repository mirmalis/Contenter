using Microsoft.AspNetCore.Components;

using XXX;

namespace Contenter.Components.Pages.CRUD.Sources.Channels;

public partial class _Display: _Displayer<Contenter.Models.Sources.Channel, Guid>
{
  public enum XX { 
    All,
    NepriskirtiFamai,
    BeFam,
    SpecificFam,
    NoContentOrNoFam,
    BeContent,
  }

  private bool ShowAll { get; set; } = true;
  private Guid? FamId { get;set;}
  private XX X { get; set; }
  private ComponentBase SourcesLoader { get; set; } = default!;
  private async Task ChangeFilter(XX x, Guid? famId)
  {
    this.X = x;
    this.FamId = famId;
  }
  private System.Linq.Expressions.Expression<Func<Contenter.Models.Sources.Source, bool>>
    ChannelContentFilter(List<Guid> priskirtiFamIds) {
      return this.X switch {
        XX.All => source => true,
        XX.BeContent => source => source.ContentId == null,
        XX.NepriskirtiFamai => source => source.Content != null && source.Content.FamId != null && !priskirtiFamIds.Contains(source.Content.FamId!.Value),
        XX.NoContentOrNoFam => source => source.Content == null || source.Content.FamId == null,
        XX.SpecificFam => source => source.Content != null && source.Content.FamId == this.FamId,
        _ => source => false
      };
  }
}
