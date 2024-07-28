namespace Aper.Api.Controllers.Models.Videos;

public class OutVideoDetails
{
  public required DateTime PublishedAt { get; set; }
  public required string Id { get; set; }
  public required string Title { get; set; }
  public required IDTitle Channel { get; set; }
}
