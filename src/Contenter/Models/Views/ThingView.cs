namespace Contenter.Models.Views;

public class ThingView: ILinkable
{
  public class ThingDefinitionView: ILinkable
  {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string PluralName { get; set; }

    public string GetId() => this.Id.ToString();
    public override string ToString() => this.Name;
  }
  public required ThingDefinitionView Definition { get; set; }
  public required Guid Id { get; set; }
  public required string Name { get; set; }

  public string GetId() => this.Id.ToString();
  public override string ToString() => this.Name;
}
