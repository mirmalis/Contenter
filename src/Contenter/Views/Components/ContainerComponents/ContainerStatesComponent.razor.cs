using Contenter.Models.Components.ComponentStates;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.ContainerComponents;

public partial class ContainerStatesComponent: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public ComponentState State { get; set; }
  [EditorRequired]
  [Parameter]
  public RenderFragment LoadingFragment { get; set; } = default!;

  [EditorRequired]
  [Parameter]
  public RenderFragment ContentFragment { get; set; } = default!;

  [EditorRequired]
  [Parameter]
  public RenderFragment ErrorFragment { get; set; } = default!;

  private RenderFragment GetComponentStateFragment()
  {
    return this.State switch {
      ComponentState.Loading => this.LoadingFragment,
      ComponentState.Content => this.ContentFragment,
      ComponentState.Error => this.ErrorFragment,
      _ => this.ErrorFragment,
    };
  }
}
