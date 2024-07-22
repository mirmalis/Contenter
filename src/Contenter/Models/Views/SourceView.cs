namespace Contenter.Models.Views;

public interface ISourceViewInner
{
  Guid Id { get; set; }
  string? Name { get; set; }
}
public interface ISourceViewOuter
{
  string Href { get; set; }
  string? Name { get; set; }
  string? IconPath { get; set; }
}
public class SourceView: ISourceViewInner, ISourceViewOuter
{
  public required Guid Id { get; set; }
  public required string Href { get; set; }
  public required string? Name { get; set; }
  public required string? IconPath { get; set; }
  public DateTime? PublishedAt { get; set; }

  public string? DefinitionUid { get; set; }

  public required ChannelView? Channel { get; set; }
  public required ContentView? Content { get; set; }

  //public RenderFragment OuterLinkFragment(string? name, int? maxLength )
  //{
  //  return builder => {
  //    builder.OpenComponent<OuterLinkSource>(1);
  //    builder.AddComponentParameter(2, "Model", this);
  //    builder.AddComponentParameter(3, "Name", name);
  //    builder.AddComponentParameter(4, "MaxLength", maxLength);
  //    builder.CloseComponent();
  //  };
  //}
}
