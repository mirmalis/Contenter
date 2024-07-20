using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public class ContentFamChannel: ILister
{
  [Required]
  public ContentFam ContentFam { get; set; } = default!;
  public Guid ContentFamId { get; set; }

  public int IndexA { get; set; }
  public int IndexB { get; set; }

  [Required]
  public Sources.Channel Channel { get; set; } = default!;
  public Guid ChannelId { get; set; }
}
