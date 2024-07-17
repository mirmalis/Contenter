using Contenter.Models.Components.ComponentStates;
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


  protected override void OnInitialized()
  {
    this.State = ComponentState.Content;
  }
}
