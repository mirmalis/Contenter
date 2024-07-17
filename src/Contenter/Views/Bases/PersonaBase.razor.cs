using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Bases;

public partial class PersonaBase: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public string Name { get; set; } = default!;
  
  [Parameter]
  public string? Image { get; set; }
}
