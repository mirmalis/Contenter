namespace Aper.Models.Videos;

public class VideoFieldChange: IIded<Guid>
{
  public Guid Id { get; set; }
  public VideoField Field { get; set; }
  public string VideoFieldVideoId { get; set; }
  public VideoFields VideoField { get; set; }
  public DateTime CreatedAt { get; set; }

  public string? Value { get; set; }
}
