namespace Aper.Models;

public class Channel: IIded<string>
{
  /// <summary>
  /// Starts with UC....
  /// </summary>
  public string Id { get; set; }
  public string? Handle { get; set; }
  public string? Title { get; set; }
  public string? Country { get; set; }
  
  public string? UploadsPlaylistId { get; set; }
  public DateTime? Since { get; set; }

  public bool IsOld()
  {
    return true;
  }
  public DateTime CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
