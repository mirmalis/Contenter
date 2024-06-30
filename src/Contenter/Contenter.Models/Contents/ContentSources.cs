using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public class ContentSources
{
	[Required]
	public Content Content { get; set; } = default!;
	public Guid ContentId { get; set; }

	[Required]
	public Sources.Source Source { get; set; } = default!;
	public Guid SourceId { get; set; }

	public int Index { get; set; }
}
