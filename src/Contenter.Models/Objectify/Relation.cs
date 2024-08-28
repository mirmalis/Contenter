using System.ComponentModel.DataAnnotations;

using Contenter.Models.Contents;

namespace Contenter.Models.Objectify;
public class Relation: IIded<Guid>, ILister
{
  public DateTime CreatedAt { get; set; }
  public Guid Id { get; set; }

  [Required]
  public Thing From { get; set; } = default!;
  public Guid FromId { get; set; }

  [Required]
  public RelationDefinition Definition { get; set; } = default!;
  public Guid DefinitionId { get; set; }

  [Required]
  public Thing To { get; set; } = default!;
  public Guid ToId { get; set; }

  public int IndexA { get; set; }
  public int IndexB { get; set; }
}
