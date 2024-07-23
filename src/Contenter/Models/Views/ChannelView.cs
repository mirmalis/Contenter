namespace Contenter.Models.Views;

public interface IChannelViewInner
{
  Guid Id { get; set; }
  string? Name { get; set; }
}
public interface IChannelViewOuter
{
  string? IconPath { get; set; }
  string? Href { get; set; }
  string? Name { get; set; }
}
public class ChannelView: IChannelViewInner, IChannelViewOuter
{
  public required Guid Id { get; set; }
  public required string? Name { get; set; }
  public required string? IconPath { get; set; }
  public required string? Href { get; set; }
}
