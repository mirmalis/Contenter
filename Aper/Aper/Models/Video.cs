
using System.Xml;

using Aper.Models.Videos;


namespace Aper.Models;

public class Video: IIded<string>
{
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }

  public void Update(Google.Apis.YouTube.v3.Data.Video data, DateTime now)
  {
    this.HandleNewFieldValue(Aper.Models.Videos.VideoFields.Title, data.Snippet.Title, now);
    this.HandleNewFieldValue(Aper.Models.Videos.VideoFields.Description, data.Snippet.Description, now);

    this.HandleNewFieldValue(Aper.Models.Videos.VideoFields.Duration, data.ContentDetails.Duration, now);

    this.Statuses.Add(
      new Models.Videos.Video_Status(this, data, now)
    );
  }
  #region Constructors
  public Video() : base() { }
  public Video(Google.Apis.YouTube.v3.Data.SearchResult data, DateTime now) : this()
  {
    this.Id = data.Id.VideoId;
    this.PublishedAt = DateTime.Parse(data.Snippet.PublishedAtRaw);
    this.AuthorId = data.Snippet.ChannelId;

    this.HandleNewFieldValue(VideoFields.Title, data.Snippet.Title, now);
    this.HandleNewFieldValue(VideoFields.Description, data.Snippet.Description, now);
  }
  #endregion
  /// <summary>
  /// also known as v parameters at http
  /// </summary>
  public string Id { get; set; }

  public Channel? Author { get; set; }
  public string? AuthorId { get; set; }

  public DateTime? PublishedAt { get; set; }
  #region Dynamic Data

  #region Fields
  public string? Title { get; set; }
  public string? Description { get; set; }
  public TimeSpan? Duration
  {
    get
    {
      var val = this.GetFieldValue(VideoFields.Duration);
      if (val == null)
        return null;
      return XmlConvert.ToTimeSpan(val);
    }
  }

  public DateTime? LastFieldChangedAt { get; private set; }
  public List<VideoField> Fields { get; set; } = [];
  public void HandleNewFieldValue(Videos.VideoFields field, string? value, DateTime now)
  {
    var str =
      value switch {
        null => null,
        _ => field.HasFlag(VideoFields.Duration) switch {
          true => XmlConvert.ToTimeSpan(value).ToString(),
          _ => value
        }
      };
    var fieldValue = this.Fields.FirstOrDefault(item => item.Field == field);
    if (field == VideoFields.Title && this.Name != str)
    {
      this.Name = str;
    }
    if (fieldValue == null)
    {
      fieldValue = new VideoField(field, str, now);
      this.Fields.Add(fieldValue);
      this.LastFieldChangedAt = now;
      return;
    }
    if (fieldValue.Value == str)
    {
      fieldValue.LatestCheck = now;
      return;
    }
    fieldValue.ChangeValue(str, now);
    this.LastFieldChangedAt = now;
  }
  private string? GetFieldValue(VideoFields field)
  {
    var fieldValue = this.Fields.FirstOrDefault(item => item.Field == field);
    return fieldValue?.Value;
  }
  #endregion
  #region Statuses
  public DateTime? LastChange_Stats { get; private set; }
  public List<Video_Status> Statuses { get; set; } = [];
  public ulong? ViewCount { get; set; }
  public ulong? LikeCount { get; set; }
  public ulong? CommentCount { get; set; }
  public string? Name { get; private set; }

  internal void Update(Video_Status data)
  {
    if (this.ViewCount == data.ViewCount
      && this.LikeCount == data.LikeCount
      && this.CommentCount == data.CommentCount)
      return;
    this.ViewCount = data.ViewCount;
    this.LikeCount = data.LikeCount;
    this.CommentCount = data.CommentCount;
    this.LastChange_Stats = data.CreatedAt;
  }
  #endregion
  #endregion
}
