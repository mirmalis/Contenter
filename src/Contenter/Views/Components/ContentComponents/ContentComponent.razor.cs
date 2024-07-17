using Contenter.Models.Components.ComponentStates;
using Contenter.Brokers.Contents;
using Contenter.Models.Views.Contents;
using Contenter.Views.Bases;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.ContentComponents;

public partial class ContentComponent: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public ContentView Data { get; set; } = default!;

  public ComponentState State { get; set; }

  public LabelBase NameLabel { get; set; }

  [Inject]
  public IContentBroker ContentBroker { get;  set; } = default!;
  private async Task<bool> unlist()
  {
    return await this.ContentBroker.ChangeMainPageListingStatus(this.Data.Id, true);
  }

  protected override void OnInitialized()
  {
    this.State = ComponentState.Content;
  }
}
