
namespace Aper.Api.Brokers.Models;

public class BasicVideoInfo
{
  public required string Id { get; set; }
  public required DateTime? PublishedAt { get; set; }
  public required string? Title { get; set; }
  public required string? Description { get; set; }
  public required BasicChannelInfo Channel { get; set; }

  public required PrivacyStatuses? PrivacyStatus { get; set; }
}
