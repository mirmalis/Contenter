using Contenter.Models.Components.ComponentStates;
using Contenter.Models.Views.Contents;
using Contenter.Services.Views.SourceViews;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.SourcesListComponents;

public partial class SourcesListComponent: ComponentBase
{
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
			this.Datas = await this.SourceViewService.GetLatest(this.Step, this.Skip);
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
    this.Datas ??= [];
    this.Skip += this.Step;
    var xs = await SourceViewService.GetLatest(this.Step, this.Skip);
    if (!xs.Any())
    {
      this.HasMore = false;
    }
    this.Datas.AddRange(xs);
    this.State = ComponentState.Content;
  }
}
