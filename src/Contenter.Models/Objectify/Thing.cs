using System.ComponentModel.DataAnnotations;

using Contenter.Models.Contents;

namespace Contenter.Models.Objectify;
public class Thing: IIded<Guid>, INameable
{
  public override string ToString() => Name;
  public Guid Id { get; set; }
  [Required]
  public ThingDefinition ThingDefinition { get; set; } = default!;
  public Guid ThingDefinitionId { get; set; }
  [Required]
  public string Name { get; set; } = default!;
  public string? Description { get; set; }

  public List<string>? Links { get; set; }
  public List<Relation>? RelationsFrom { get; set; }
  public List<Relation>? RelationsTo { get; set; }
  public List<ContentGuests<Thing>>? ContentAssignments { get; set; }
}
