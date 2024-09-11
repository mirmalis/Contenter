namespace Contenter.Models.Objectify.Sets;
public class Set: IIded<Guid>
{
  public Guid Id { get; set; }
  public List<IntersectionMemberAssignment>? Intersections { get; set; }
}
