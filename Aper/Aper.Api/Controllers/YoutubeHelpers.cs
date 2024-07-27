namespace Aper.Api.Controllers;

public static class YoutubeHelpers
{
  private static readonly System.Text.RegularExpressions.Regex r1 = new(@"https:\/\/www\.youtube\.com\/watch\?v=(.{11})");
  private static readonly System.Text.RegularExpressions.Regex r2 = new(@"https:\/\/youtu\.be/(.{11})");
  private static readonly System.Text.RegularExpressions.Regex r3 = new(@"https:\/\/www\.youtube\.com\/shorts\/(.{11})");


  public static string? ExtractV(string identifier)
  {
    if (identifier.Length < 11)
      return null;
    if (identifier.Length == 11)
      return identifier;
    var m1 = r1.Match(identifier);
    if (m1.Success)
    {
      return m1.Groups[1].Value;
    }
    var m2 = r2.Match(identifier);
    if (m2.Success)
    {
      return m2.Groups[1].Value;
    }
    var m3 = r3.Match(identifier);
    if (m3.Success)
    {
      return m3.Groups[1].Value;
    }
    return null;
  }
}
