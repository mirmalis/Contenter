using Contenter.Models.Views.Contents;

using Microsoft.AspNetCore.Components;

namespace Contenter.Views.Components.ContentFamComponents;

public partial class ContentFamComponent: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public ContentFamView Data { get; set; } = default!;
}
