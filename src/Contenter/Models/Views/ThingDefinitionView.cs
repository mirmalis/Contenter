namespace Contenter.Models.Views;

public class ThingDefinitionView
{
  public class ScopeView
  {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
  }
  public required Guid Id { get; set; }
  public required ScopeView Scope { get; set; }
  public required string Name { get; set; }
}
