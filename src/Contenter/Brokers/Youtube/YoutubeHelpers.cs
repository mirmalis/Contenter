namespace Contenter.Brokers.Youtube;

public static class YoutubeHelpers
{
  private static System.Text.RegularExpressions.Regex[] regularExpressions = 
  [
    new(@"https:\/\/www\.youtube\.com\/watch\?v=(.{11})"),
    new(@"https:\/\/youtu\.be/(.{11})"),
    new(@"https:\/\/www\.youtube\.com\/shorts\/(.{11})"),
    new(@"https:\/\/www\.youtube\.com\/embed\/(.{11})")
  ];
  public static string? ExtractV(string identifier)
  {
    if (identifier.Length < 11)
      return null;
    if (identifier.Length == 11)
      return identifier;

    foreach (var regex in regularExpressions)
    {
      var match = regex.Match(identifier);
      if (match.Success)
      {
        return match.Groups[1].Value;
      }
    }
    return null;
  }
}
