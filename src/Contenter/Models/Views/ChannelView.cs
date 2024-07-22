namespace Contenter.Models.Views;

public class ChannelView
{
  public required Guid Id { get; set; }
  public required string? Name { get; set; }
  public required string? IconPath { get; set; }
  public required string? Href { get; set; }
}
