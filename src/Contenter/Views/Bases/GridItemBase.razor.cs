using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class GridItemBase: ComponentBase
{

  [Parameter]
  public int XS { get; set; } = 6;

  [Parameter]
  public int SM { get; set; } = 3;

  [EditorRequired]
  [Parameter]
  public RenderFragment ChildContent { get; set; } = default!;
}
