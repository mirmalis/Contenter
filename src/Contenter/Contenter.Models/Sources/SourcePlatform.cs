using System.ComponentModel.DataAnnotations;

namespace Contenter.Models.Sources;
public class SourcePlatform: IIded<string>
{
  [Key]
  public string Id { get; set; } = default!;
  [Required]
  public string Name { get; set; } = default!;

  public List<SourceDefinition> Definitions { get; set; } = [];

}
