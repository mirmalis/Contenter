//using System.Numerics;
//using System.Text.Json;
//using System.Xml;

//using Google.Apis.Services;
//using Google.Apis.YouTube.v3;
//using Google.Apis.YouTube.v3.Data;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Aper.Api.Controllers;
//[ApiController]
//[Microsoft.AspNetCore.Mvc.Route("[controller]")]
//public class YoutubeVideoController: ControllerBase
//{
//  #region Constructors
//  private readonly Database db;
//  private readonly YouTubeService youtubeService;
//  public YoutubeVideoController(Database db)
//  {
//    this.db = db;
//    this.youtubeService = new YouTubeService(
//      new BaseClientService.Initializer
//      {
//        ApiKey = "AIzaSyAGrDrmtWkOzLdfF_c7bVKobymzwFIWWig",
//        ApplicationName = "apier-425516"
//      }
//    );
//  }
//  #endregion

//  #region v
//  private static readonly System.Text.RegularExpressions.Regex r1 = new(@"https:\/\/www\.youtube\.com\/watch\?v=(.{11})");
//  private static readonly System.Text.RegularExpressions.Regex r2 = new(@"https:\/\/youtu\.be/(.{11})");
//  private static readonly System.Text.RegularExpressions.Regex r3 = new(@"https:\/\/www\.youtube\.com\/shorts\/(.{11})");
//  private string? ExtractV(string identifier)
//  {
//    if(identifier.Length < 11)
//      return null;
//    if (identifier.Length == 11)
//      return identifier;
//    var m1 = r1.Match(identifier);
//    if (m1.Success)
//    {
//      return m1.Groups[1].Value;
//    }
//    var m2 = r2.Match(identifier);
//    if (m2.Success)
//    {
//      return m2.Groups[1].Value;
//    }
//    var m3 = r3.Match(identifier);
//    if (m3.Success)
//    {
//      return m3.Groups[1].Value;
//    }
//    return null;
//  }
//  #endregion
//  [HttpPost]
//  public async Task<ActionResult<Api.Youtube.Video>> PostVideoInfoParse(string identifier)
//  {
//    var v = ExtractV(identifier);
//    if(v == null)
//      return BadRequest();
//    return await fetchVideoInfo(v);
//  }
//  async Task<ActionResult<Api.Youtube.Video>> fetchVideoInfo(string videoId)
//  {
//    List<string> keys = [
//      //"id",
//      "snippet", //
//      "contentDetails", // Duration
//      //"liveStreamingDetails",
//      //"localizations",
//      //"recordingDetails",
//      "statistics",
//      "status",
//      "topicDetails",

//      //"fileDetails",
//      //"player",
//      //"processingDetails",
//      //"suggestions",
//    ];
//    var dataKeys = string.Join(",", keys);
//    var searchRequest = youtubeService.Videos.List(dataKeys);
//    searchRequest.Id = videoId;

//    var searchResponse = await searchRequest.ExecuteAsync();
//    var items = searchResponse.Items;
//    var existings = await this.db.Videos
//      .Where(item => items.Select(item => item.Id).ToArray().Contains(item.Id))
//      .Include(item => item.Fields)
//      .ToListAsync();
//    var nowUtc = DateTime.UtcNow;
    
//    if(items.Count != 1)
//      return NotFound();
//    var item = items.First();
//    var channel =
//        await this.db.Channels.FirstOrDefaultAsync(ch => ch.Id == item.Snippet.ChannelId)
//        ??
//        new Models.Channel() {
//          Id = item.Snippet.ChannelId,
//          Title = item.Snippet.ChannelTitle,
//        };
//    var video = existings.FirstOrDefault(item => item.Id == item.Id) ?? new Models.Video() {
//      Author = channel,
//      Id = item.Id,
//      PublishedAt = DateTime.Parse(item.Snippet.PublishedAtRaw)
//    };
//    video.Update(item, nowUtc);
//    db.AddRange(video);
//    //db.AddRange(obs1, obs3);
//    await db.SaveChangesAsync();
//    return Ok(Selectors.Video_YoutubeVideo.Compile().Invoke(video));
//  }

//  [HttpGet]
//  public async Task<ActionResult<Api.Youtube.Video>> gGetVideoInfo(string identifier)
//  {
//    var v = this.ExtractV(identifier);
//    if(v == null)
//      return BadRequest("Failed to get videoId");

//    var result = await getVideoInfo(v);
//    if(result != null)
//      return Ok(result);
//    return await PostVideoInfoParse(v);
//  }
//  async Task<Youtube.Video?> getVideoInfo(string videoId)
//  {
//    var video = await this.db.Videos
//      .Where(item => item.Id == videoId)
//      .Select(Selectors.Video_YoutubeVideo)
//      .FirstOrDefaultAsync();
//    return video;
//  }
//}
