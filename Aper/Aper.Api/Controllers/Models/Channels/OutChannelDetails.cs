
namespace Aper.Api.Controllers.Models.Channels;

public class OutChannelDetails
{
  public required DateTime PublishedAt { get; set; }
  public required string Id { get; set; }
  public required string? Title { get; set; }
  public required string? Handle { get; set; }
  public required string? Country { get; set; }
  public required string? UploadsPlaylist { get; set; }
}
