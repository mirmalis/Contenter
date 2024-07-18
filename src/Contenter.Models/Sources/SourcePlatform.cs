using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Sources;
public class SourcePlatform: IIded<string>
{
  public override string ToString() => this.Name;
  [Key]
  public string Id { get; set; } = default!;
  [Required]
  public string Name { get; set; } = default!;
  [Required]
  public string IconPath { get; set; } = default!;

  public List<Channel> Channels { get; set; } = [];
  public List<SourceDefinition> Definitions { get; set; } = [];
}
