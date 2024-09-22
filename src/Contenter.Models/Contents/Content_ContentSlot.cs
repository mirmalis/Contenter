using System.ComponentModel.DataAnnotations;

using Contenter.Models.Objectify;

namespace Contenter.Models.Contents;
public class Content_ContentSlot: IIded<Guid>, ILister
{
  public DateTime CreatedAt { get; set; }
  public Guid Id { get; set; }

  [Required]
  public Content Content { get; set; } = default!;
  public Guid ContentId { get; set; }

  [Required]
  public Slot Slot { get; set; } = default!;
  public string SlotId { get; set; } = default!;

  public List<ContentGuests<Thing>>? ThingAssignments { get; set; }
  public int IndexA { get; set; }
  public int IndexB { get; set; }
}
