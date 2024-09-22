using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public enum SlotFlags: UInt64
{
  None = 0,
  IsNotImportant = 1 << 0,
}
public class Slot: IIded<string>, INameable
{
  public override string ToString() => this.Name;
  public string Id { get; set; }
  public SlotFlags Flags { get; set; } = SlotFlags.None;

  [Required]
  public string Name { get; set; } = default!;
  [Required]
  public string NamePlural { get; set; } = default!;

  public List<ContentDefinition>? ContentDefinitions { get; set; }
  public List<Content_ContentSlot>? ContentAssignments { get; set; }
}
