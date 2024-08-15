using System.ComponentModel.DataAnnotations;
using Contenter.Models.Contents;

namespace Contenter.Models.Objectify;
public class Thing : IIded<Guid>
{
    public override string ToString() => Name;
    public Guid Id { get; set; }
    public ThingDefinition? ThingDefinition { get; set; }
    public Guid? ThingDefinitionId { get; set; }
    [Required]
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public List<string>? Links { get; set; }

    public List<ContentGuests<Thing>> ContentAssignments { get; set; } = [];
}
