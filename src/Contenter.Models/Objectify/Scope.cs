namespace Contenter.Models.Objectify;
public class Scope: IIded<Guid>
{
  public override string ToString() => this.Name;
  public Guid Id { get; set; }
  public string Name { get; set; }
  public List<ThingDefinition> ThingDefinitions { get; set; } = [];
}
