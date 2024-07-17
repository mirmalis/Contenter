using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class NavMenuBase: ComponentBase
{
  private bool expanded = true;

  [Parameter]
  public RenderFragment ChildContent { get; set; }
}
