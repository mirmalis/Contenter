namespace Contenter.Components.Pages;

internal static class Js
{
  public static readonly string YoutubeVideo =
    """
    javascript:(
      function ()
      {
        const host = "https://sars.lt";
        (async function () {
          window.open(`${host}/create/s/sources?PlatformId=yt&Href=${document.location.href}&bookmarkletversion=1`, "_blank");
        })();
      }
    )();
    """;
}
