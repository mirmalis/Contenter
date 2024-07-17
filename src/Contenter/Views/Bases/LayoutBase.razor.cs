using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class LayoutBase: ComponentBase
{
  [Parameter]
  public RenderFragment Header { get; set; }

  [Parameter]
  public RenderFragment Main { get; set; }

  [Parameter]
  public RenderFragment NavigationMenu { get; set; }

  [Parameter]
  public RenderFragment Footer { get; set; }
}
