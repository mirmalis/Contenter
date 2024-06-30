using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public class Content: IIded<Guid>
{
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  
  public ContentFam? Fam { get; set; } 
  public Guid? FamId { get; set; }

  [Required]
  public string Name { get; set; } = default!;

  public List<ContentGuests<Contenter.Models.Persons.Persona>> GuestPersonaAssignments { get; set; } = [];
  public List<ContentSources> SourceAssignments { get; set; } = [];
}
