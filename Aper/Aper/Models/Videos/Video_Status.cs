using System.ComponentModel.DataAnnotations;

namespace Aper.Models.Videos;

public class Video_Status: IIded<Guid>
{
  #region Constructors
  public Video_Status() : base() { }
  public Video_Status(Video video, Google.Apis.YouTube.v3.Data.Video data, DateTime nowUtc) : this()
  {
    if (data.Statistics == null)
      throw new Exception($"data.Statistics is required for {nameof(Video_Status)} constructor.");
    this.CreatedAt = nowUtc;

    this.ViewCount = data.Statistics.ViewCount;
    this.LikeCount = data.Statistics.LikeCount;
    this.CommentCount = data.Statistics.CommentCount;
    this.DislikeCount = data.Statistics.DislikeCount;
    this.FavoriteCount = data.Statistics.FavoriteCount;
    if (video != null)
    {
      this.Video = video;
      this.Video.Update(this);
      this.Video.ViewCount = data.Statistics.ViewCount;
      this.Video.LikeCount = data.Statistics.LikeCount;
      this.Video.CommentCount = data.Statistics.CommentCount;
    }
  }
  #endregion
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }

  [Required]
  public Video Video { get; set; } = default!;
  public string VideoId { get; set; } = null!;

  public ulong? ViewCount { get; set; }
  public ulong? LikeCount { get; set; }
  public ulong? CommentCount { get; set; }
  public ulong? DislikeCount { get; set; }
  public ulong? FavoriteCount { get; set; }
}
