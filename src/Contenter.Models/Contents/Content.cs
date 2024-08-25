using Contenter.Models.Objectify;

namespace Contenter.Models.Contents;
[Flags]
public enum ContentFlags: UInt64
{
  Everywhere = 0,
  NotAtMain = 1,
}
public class Content: IIded<Guid>
{
  public override string? ToString() => this.Name;
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? PublishedAt { get; set; }

  public ContentFam? Fam { get; set; } 
  public Guid? FamId { get; set; }

  public string? Name { get; set; } = default!;

  public ContentFlags Flags { get; set; }

  public List<ContentGuests<Thing>> GuestPersonaAssignments { get; set; } = [];
  public List<Sources.Source> Sources { get; set; } = [];
}
