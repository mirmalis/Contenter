using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class SkeletonBase: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public RenderFragment ChildContent { get; set; } = default!;

  [Parameter]
  public string Height { get; set; } = "100%";

  [Parameter]
  public string Width { get; set; } = "100%";
}
