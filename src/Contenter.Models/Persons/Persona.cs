using System.ComponentModel.DataAnnotations;

using Contenter.Models.Contents;

namespace Contenter.Models.Persons;
public class Persona: IIded<Guid>
{
  public override string ToString() => this.Name;
  public Guid Id { get; set; }

  [Required]
  public string Name { get; set; } = default!;
  public string? Description { get; set; }

  public List<string>? Links { get; set; }

  public List<ContentGuests<Contenter.Models.Persons.Persona>> ContentAssignments { get; set; } = [];
}
