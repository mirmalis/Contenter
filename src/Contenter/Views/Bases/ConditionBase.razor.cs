using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class ConditionBase: ComponentBase
{
  [Parameter]
  public bool Condition { get; set; }

  [Parameter]
  public RenderFragment Match { get; set; }

  [Parameter]
  public RenderFragment NotMatch { get; set; }
}
