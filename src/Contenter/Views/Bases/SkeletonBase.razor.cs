using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class SkeletonBase: ComponentBase
{
  [Parameter]
  public RenderFragment ChildContent { get; set; }

  [Parameter]
  public string Height { get; set; } = "100%";

  [Parameter]
  public string Width { get; set; } = "100%";
}
