using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Sources;
public class Channel: IIded<Guid>
{
  public override string ToString() => this.Title ?? this.Name ?? this.Handle ?? this.Uid ?? "no-name";
  public Guid Id { get; set; }

  [Required]
  public SourcePlatform Platform { get; set; } = default!;
  public string PlatformId { get; set; } = default!;

  public string? Href { get; set; }
  public string? Uid { get; set; }
  public string? Name { get; set; }
  public string? Handle { get; set; }
  public string? Title { get; set; }

  public List<Source> Sources { get; set; } = [];
  public List<Contents.ContentFam> CotentFams { get; set; } = [];
  public List<Contents.ContentFamChannel> CotentFamsAssignments { get; set; } = [];
}
