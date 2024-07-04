﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contenter.Models.Sources;
public enum SourceFlags
{
  None,
  Preview,
  Paid,
  Unlisted,
}
public class Source: IIded<Guid>
{
  public override string ToString() => this.Href;
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }

  [Required]
  public string Href { get; set; } = default!;


  public SourceFlags Flags { get; set; } = SourceFlags.None;
  public bool IsFlag(SourceFlags flag) => this.Flags.HasFlag(flag);
  public void SetFlag(SourceFlags flag, bool value) {

    if((this.Flags.HasFlag(flag) && value) || (!this.Flags.HasFlag(flag) && !value)) 
      return;
    if (value)
    {
      this.Flags = this.Flags | flag;
      
    } else
    {
      this.Flags = this.Flags ^ flag;
    }
  }
  

  public SourceDefinition? Definition { get; set; }
  public SourcePlatform? Platform { get; set; }
  public string? PlatformId { get; set; }
  public string? DefinitionUid { get; set; }

  public List<Contents.ContentSources> ContentAssignments { get; set; } = [];
}
