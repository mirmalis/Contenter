using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class ConditionBase: ComponentBase
{
  [Parameter]
  public bool Condition { get; set; }

  [EditorRequired]
  [Parameter]
  public RenderFragment Match { get; set; } = default!;

  [Parameter]
  public RenderFragment? NotMatch { get; set; }
}
