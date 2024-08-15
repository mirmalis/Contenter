using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Objectify;
[Flags]
public enum ThingDefinitionFlags
{
  None = 0,
  ListedAtContent = 1 << 0,
}
public class ThingDefinition: IIded<Guid>
{
  public Guid Id { get; set; }
  public ThingDefinitionFlags Flags { get; set; }
  [Required]
  public Scope Scope { get; set; } = default!;
  public Guid ScopeId { get; set; }

  public string Name { get; set; } = default!;
  public List<Thing> Instances { get; set; } = [];
}
