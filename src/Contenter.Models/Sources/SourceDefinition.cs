using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Sources;
public class SourceDefinition
{
  public override string ToString() => this.Name;
  [Required]
	public SourcePlatform Platform { get; set; } = default!;
	public string PlatformId { get; set; } = default!;
	[Required]
	public string Uid { get; set; } = default!;

	[Required]
	public string Name { get; set; } = default!;

	public List<Source> Instances { get; set; } = [];
}
