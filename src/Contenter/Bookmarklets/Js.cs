namespace Contenter.Bookmarklets;

internal static class Js
{
    public static readonly string YoutubeVideo = BookmarkletFromFile("./Bookmarklets/yt_video-open-source_creation.js");
    public static readonly string YoutubePostVideo = BookmarkletFromFile("./Bookmarklets/yt_video-post-source_creation.js");

    private static string BookmarkletFromFile(string path)
    {
        var indent = "";
        string code = File.ReadAllText(path);
        string codeIndented = string.Join("\n", code.Split('\n').Select(line => indent + line));

        return
        $$"""
    javascript:(
    function ()
    {
    {{codeIndented}}
    }
    )();
    """;
    }
}
