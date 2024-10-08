﻿using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public class ContentGuests<TGuest>: ILister
	where TGuest : class, IIded<Guid>
{
	[Required]
	public Content Content { get; set; } = default!;
	public Guid ContentId { get; set; }

	[Required]
	public TGuest Guest { get; set; } = default!;
	public Guid GuestId { get; set; }

	public int IndexA { get; set; }
	public int IndexB { get; set; }
	[Required]
	[Range(0, 100)]
	public int? Percentage { get; set; }

	public Slot? Slot { get; set; }
  public Content_ContentSlot? SlotAss { get; set; }
  public string? SlotId { get; set; }
}
