namespace Contenter.Models.Views;

public class ContentView
{
  public required Guid Id { get; set; }
  public required string? Name { get; set; }
  public required FamView? Fam { get; set; }
  public DateTime? PublishedAt { get; set; }
  public required IEnumerable<ThingView> Things { get; set; }
  public required IEnumerable<SourceView>? Sources { get; set; }
}
