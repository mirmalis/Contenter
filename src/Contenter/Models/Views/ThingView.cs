namespace Contenter.Models.Views;

public class ThingView
{
  public class ThingDefinitionView
  {
    public required Guid Id { get; set; }
    public required string Name { get; set; }
  }
  public required ThingDefinitionView? Definition { get; set; }
  public required Guid Id { get; set; }
  public required string Name { get; set; }
}
