using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Objectify.Sets;
public class IntersectionMemberAssignment: IIded<Guid>
{
  public Guid Id { get; set; }
  [Required]
  public Set Set { get; set; } = default!;
  public Guid SetId { get; set; }

  [Required]
  public Thing Thing { get; set; } = default!;
  public Guid ThingId { get; set; }
}
