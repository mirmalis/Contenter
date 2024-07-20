namespace Contenter.Models.Views.Contents;

public class SourceView
{
  public required Guid Id { get; set; }

  public required DateTime? PublishedAt { get; set; }
  public required string Href { get; set; }
  public required string? Name { get; set; }
  public required string? IconPath { get; set; }

  public required SourceChannelView? Channel { get; set; }
}
