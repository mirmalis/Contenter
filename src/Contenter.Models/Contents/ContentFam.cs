using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public class ContentFam: IIded<Guid>
{
  public override string ToString() => this.Name;
  public Guid Id { get; set; }

  public ContentFam? Parent { get; set; } 
  public Guid? ParentId { get; set; }
  public List<ContentFam> Children { get; set; } = [];

  [Required]
  public string Name { get; set; } = default!;

  public List<string> PayLinks { get; set; } = [];
  public List<Content> Contents { get; set; } = [];
}
