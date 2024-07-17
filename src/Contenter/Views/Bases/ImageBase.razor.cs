using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class ImageBase: ComponentBase
{
  [Parameter]
  public string Source { get; set; }

  [Parameter]
  public string Alt { get; set; }

  [Parameter]
  public string Width { get; set; }

  [Parameter]
  public string Height { get; set; }

  public string GetImageSource() =>
      this.Source;
}
