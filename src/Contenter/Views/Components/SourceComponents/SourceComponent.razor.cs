using System.Runtime.Versioning;

using Contenter.Models.Views.Contents;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.SourceComponents;

public partial class SourceComponent: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public SourceView Data { get; set; } = default!;
}
