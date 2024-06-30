using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Sources;
public class SourceDefinition
{
	[Required]
	public SourcePlatform Platform { get; set; } = default!;
	public string PlatformId { get; set; } = default!;
	[Required]
	public string Uid { get; set; } = default!;

	public List<Source> Instances { get; set; } = [];
}
