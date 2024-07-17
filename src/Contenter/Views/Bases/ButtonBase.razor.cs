using System;
using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;
public partial class ButtonBase: ComponentBase
{
  [Parameter]
  public string? Text { get; set; }

  [Parameter]
  public Action? OnClick { get; set; }

  [Parameter]
  public bool IsDisabled { get; set; }

  public void Click() => this.OnClick?.Invoke();

  public void Disable()
  {
    this.IsDisabled = true;
    InvokeAsync(StateHasChanged);
  }

  public void Enable()
  {
    this.IsDisabled = false;
    InvokeAsync(StateHasChanged);
  }
}
