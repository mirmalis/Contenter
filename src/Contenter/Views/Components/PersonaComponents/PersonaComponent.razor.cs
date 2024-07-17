using Contenter.Models.Views.Contents;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.PersonaComponents;

public partial class PersonaComponent: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public PersonaView Data { get; set; } = default!;
}
