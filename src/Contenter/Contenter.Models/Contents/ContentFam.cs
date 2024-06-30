using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public class ContentFam: IIded<Guid>
{
  public override string ToString() => this.Name;
  public Guid Id { get; set; }

  [Required]
  public string Name { get; set; } = default!;

  public List<Content> Contents { get; set; } = [];
}
