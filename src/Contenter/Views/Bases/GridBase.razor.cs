using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class GridBase: ComponentBase
{
  [Parameter]
  public int Spacing { get; set; } = 1;

  [EditorRequired]
  [Parameter]
  public RenderFragment ChildContent { get; set; } = default!;
}
