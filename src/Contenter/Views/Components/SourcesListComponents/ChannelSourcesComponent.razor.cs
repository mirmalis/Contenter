using Contenter.Models.Components.ComponentStates;
using Contenter.Models.Views.Contents;
using Contenter.Services.Views.SourceViews;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.SourcesListComponents;

public partial class ChannelSourcesComponent: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public Guid ChannelId { get; set; }
  [Parameter]
  public int Skip { get; set; } = 0;
  [Parameter]
  public int Step { get; set; } = 10;
  [Inject]
  public ISourceViewService SourceViewService { get; set; } = default!;

  private List<SourceView> Datas;
  public ComponentState State { get; set; }

  protected override async Task OnInitializedAsync()
  {
    try
    {
      await More(true);
    }
    catch
    {
      this.State = ComponentState.Error;
    }
  }

  private bool HasMore { get; set; } = true;
  private async Task More(bool firstLoad = false)
  {
    this.Datas ??= [];
    var xs = await SourceViewService.GetChannelSources(this.ChannelId, this.Step, this.Skip);
    if (xs.Count() < this.Step)
    {
      this.HasMore = false;
    }
    this.Datas.AddRange(xs);
    this.Skip += this.Step;
    this.State = ComponentState.Content;
  }
}
