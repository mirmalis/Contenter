using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Contents;
public enum SaveState
{
  None,
  ToDo,
  ToFinish,
  Finished
}
public class ContentSave
{
  public DateTime CreatedAt { get; set; }
  [Required]
  public Content Content { get; set; } = default!;
  public Guid ContentId { get; set; }

  [Required]
  public string ApplicationUserId { get; set; } = default!;

  public SaveState State { get; set; } = SaveState.None;
}
