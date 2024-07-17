using Contenter.Models.Contents;

namespace Contenter.Models.Views.Contents;

public class ContentView
{
  public required Guid Id { get; set; }
  public required string? Name { get; set; }

  public required ContentFamView? Fam { get; set; }

  public required IEnumerable<SourceView> Sources { get; set; }
  public required IEnumerable<PersonaView> Guests { get; set; }
}
