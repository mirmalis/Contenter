using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Sources;
public class Source: IIded<Guid>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }

  [Required]
  public string Href { get; set; } = default!;

  public SourceDefinition? Definition { get; set; }
  public SourcePlatform? Platform { get; set; }
  public string? PlatformId { get; set; }
  public string? DefinitionUid { get; set; }
}
