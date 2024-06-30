using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Persons;
public class Person: IIded<Guid>
{
  public override string ToString() => this.Name;
  public Guid Id { get; set; }

  [Required]
  public string Name { get; set; } = default!;

  public List<Persona> Personas { get; set; } = [];
}
