using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class NavMenuBase: ComponentBase
{
  private bool expanded = false;

  [EditorRequired]
  [Parameter]
  public RenderFragment ChildContent { get; set; } = default!;
}
