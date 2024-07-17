using Contenter.Models.Components.ComponentStates;
using Contenter.Models.Views.Contents;
using Contenter.Services.Views.ContentViews;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.ContentsListComponents;

public partial class ContentsListComponent: ComponentBase
{
  [Parameter]
  public int Skip { get; set; } = 0;
  [Parameter]
  public int Step { get; set; } = 10;

  [Inject]
  public IContentViewService ContentViewService { get; set; } = default!;

  public ComponentState State { get; set; }
  public List<ContentView>? ContentViews;

  protected override async Task OnInitializedAsync()
  {
    try
    {
      this.ContentViews = await ContentViewService.GetLatestVideos(this.Step, this.Skip);
      this.State = ComponentState.Content;
    }
    catch
    {
      this.State = ComponentState.Error;
    }
  }
  private bool HasMore { get; set; } = true;
  private async Task More()
  {
    this.ContentViews ??= [];
    this.Skip += this.Step;
    var xs = await ContentViewService.GetLatestVideos(this.Step, this.Skip);
    if (!xs.Any())
    {
      this.HasMore = false;
    }
    this.ContentViews.AddRange(xs);
    this.State = ComponentState.Content;
  }
}
