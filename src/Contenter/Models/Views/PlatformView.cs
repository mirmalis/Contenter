namespace Contenter.Models.Views;

public interface IPlatformViewInner
{
  string Id { get; set; }
  string Name { get; set; }
  string IconPath { get; set; }
}
public class PlatformView: IPlatformViewInner
{
  public required string Id { get; set; }
  public required string Name { get; set; }
  public required string IconPath { get; set; }
}
