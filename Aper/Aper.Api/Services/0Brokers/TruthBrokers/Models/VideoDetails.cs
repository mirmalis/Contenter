namespace Aper.Api.Services._0Brokers.TruthBrokers.Models;

public class VideoDetails
{
    public required string Id { get; set; }
    public required DateTimeOffset PublishedAt { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required BasicChannelInfo Channel { get; set; }
}
