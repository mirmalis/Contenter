namespace Aper.Api.Controllers.Models.Playlists;

public class OutPlaylistDetails
{
  public required DateTime PublishedAt { get; set; }
  public required string Id { get; set; }
  public required string Title { get; set; }
  public required long? CurrentItemsCount { get; set; }
  public required IDTitle Channel { get; set; }
  public required Accessibility? Accessibility { get; set; }
}
