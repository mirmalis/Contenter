using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;

public partial class AnchorBase: ComponentBase
{
  [Parameter]
  public string NoText { get; set; } = "no-name";
  [Parameter]
  public string? IconStart { get; set; }
  [Parameter]
  public int? MaxLength { get; set; } = null;

  [EditorRequired]
  [Parameter]
  public string href { get; set; } = default!;

  [EditorRequired]
  [Parameter]
  public string? Text { get; set; } = default!;
  [Parameter]
  public bool NewTab { get; set; }
  private string GetText()
  {
    if(string.IsNullOrWhiteSpace(this.Text))
      return this.NoText;

    if (this.MaxLength == null || this.Text.Length < this.MaxLength.Value)
    {
      return this.Text;
    }
    return this.Text[..this.MaxLength!.Value] + "..";
  }
  private string? GetTarget()
  {
    return this.NewTab switch {
      true => "_blank",
      _ => null,
    };
  }
  private string? GetClass()
  {
    if(string.IsNullOrWhiteSpace(this.Text))
      return "no-name";
    return null;
  }
}
