using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.FluentUI.AspNetCore.Components;
using Contenter.Models.Components.IconNames;

namespace Contenter.Views.Bases;
public partial class NavLinkBase: ComponentBase
{
  [EditorRequired]
  [Parameter]
  public string Href { get; set; } = default!;

  [Parameter]
  public IconName Icon { get; set; }

  [EditorRequired]
  [Parameter]
  public string Text { get; set; } = default!;

  [Parameter]
  public bool MatchAll { get; set; }

  private Icon GetFluentUIIcon() => Icon switch {
    IconName.Home => new Icons.Regular.Size20.Home(),
    IconName.Contents => new Icons.Regular.Size20.Tv(),
    _ => new Icons.Regular.Size20.Home()
  };

  private NavLinkMatch GetNavLinkMatch() =>
      MatchAll ? NavLinkMatch.All : NavLinkMatch.Prefix;
}
