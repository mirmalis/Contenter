namespace Contenter.Models.Contents;
public class ContentDefinition: IIded<Guid>, INameable
{
  public override string ToString() => this.Name;

  public Guid Id { get; set; }
  public string Name { get; set; } = default!;

  public List<Slot>? GrantedSlots { get; set; }

  public List<Content>? Instances { get; set; }
}
