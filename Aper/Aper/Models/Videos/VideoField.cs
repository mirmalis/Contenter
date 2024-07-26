using System.ComponentModel.DataAnnotations;

namespace Aper.Models.Videos;

public class VideoField
{
  #region Constructors
  public VideoField() : base() { }
  public VideoField(VideoFields field, string? value, DateTime now) : this()
  {
    this.Field = field;
    this.Value = value;
    this.CreatedAt = now;
    this.LatestCheck = now;
    this.LatestChange = now;
  }
  #endregion
  public DateTime CreatedAt { get; set; }
  public DateTime LatestCheck { get; set; }
  public DateTime LatestChange { get; set; }
  [Required]
  public Video Video { get; set; } = default!;
  public string VideoId { get; set; } = default!;
  public VideoFields Field { get; set; }

  public string? Value { get; set; }
  public List<VideoFieldChange> Changes { get; set; } = [];

  public void ChangeValue(string? value, DateTime now)
  {
    this.Changes.Add(
      new VideoFieldChange() {
        Value = this.Value,
        CreatedAt = now,
      }
    );
    this.Value = value;
    this.LatestCheck = now;
    this.LatestChange = now;
  }
}
