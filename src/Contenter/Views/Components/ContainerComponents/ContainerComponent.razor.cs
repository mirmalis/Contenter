using Contenter.Models.Components.ComponentStates;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.ContainerComponents;

public partial class ContainerComponent: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public ComponentState State { get; set; }

  [Parameter]
  public RenderFragment? Loading { get; set; }

  [EditorRequired]
  [Parameter]
  public RenderFragment Content { get; set; } = default!;

  [Parameter]
  public string? Error { get; set; }
}
