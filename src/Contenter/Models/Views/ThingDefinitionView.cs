namespace Contenter.Models.Views;

public class ThingDefinitionView: ILinkable
{
  public class ScopeView: ILinkable
  {
    public override string ToString() => this.Name;
    public string GetId() => this.Id.ToString();
    public required Guid Id { get; set; }
    public required string Name { get; set; }
  }
  public required Guid Id { get; set; }
  public required ScopeView? Scope { get; set; }
  public required string Name { get; set; }
  public override string ToString() => this.Name;
  public string GetId() => this.Id.ToString();
}
