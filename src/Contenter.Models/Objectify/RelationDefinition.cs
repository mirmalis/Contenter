using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contenter.Models.Objectify;
[Flags]
public enum RelationDefinitionFlags: UInt64
{
  None = 0,
  One = 1,
  Many = 2,
  ToOne = 4,
  ToMany = 8,
  IsParentChildRelation = 16,
}
public class RelationDefinition: IIded<Guid>, INameable
{
  public override string ToString() => this.Id.ToString();

  public Guid Id { get; set; }
  public RelationDefinitionFlags Flags { get; set; }

  [Required]
  public ThingDefinition From { get; set; } = default!;
  public Guid FromId { get; set; }

  [Required]
  public ThingDefinition To { get; set; } = default!;
  public Guid ToId { get; set; }

  public string? ForwardWord { get; set; } = default!;
  [Required]
  [Column(name: "ForwardName")]
  public string Name { get; set; } = default!;
  public string? BackWord { get; set; }
  public string? BackName { get; set; }

  

  public List<Relation>? Instances { get; set; }
}
