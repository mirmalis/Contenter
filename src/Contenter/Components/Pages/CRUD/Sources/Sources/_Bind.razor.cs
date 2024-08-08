using Contenter.Brokers.Youtube;

using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

using XXX;

namespace Contenter.Components.Pages.CRUD.Sources.Sources;

public partial class _Bind: _Binder<Contenter.Models.Sources.Source>
{
  [Parameter]
  public string? Href { get; set; }
  override protected async Task OnParametersSetAsync()
  {
    await base.OnParametersSetAsync();
    if(this.Href != null)
    {
      await this.SetHref(this.Href);
    }
  }
  [Inject] public IYoutubeBroker yt { get; set; } = default!;
  private async Task SetHref(string href)
  {
    if((this.model.Platform?.Id ?? this.model.PlatformId) == "yt")
    {
      var ytInfo = await this.yt.GetVideoInfo(href);
      if (ytInfo != null)
      {
        this.model.Definition = await this.db.Set<Contenter.Models.Sources.SourceDefinition>()
          .Include(item => item.Platform)
          .FirstOrDefaultAsync(item => item.Uid == "video" && item.PlatformId == "yt");
        this.model.Platform = this.model.Definition?.Platform;
        this.model.Channel = await this.db.Channels.FirstOrDefaultAsync(item => item.Uid == ytInfo.Channel.Id)
          ?? new Models.Sources.Channel() {
            Uid = ytInfo.Channel.Id,
            Title = ytInfo.Channel.Title,
            PlatformId = "yt",
            Href = ytInfo.Channel.Href,
          };
        this.model.Href = ytInfo.Href;
        this.model.Name = ytInfo.Title;
        this.model.PublishedAt = ytInfo.PublishedAt;
      }
    }
    else
    {
      this.model.Href = href;
    }
  }


  private async Task InitializeContent(Guid? famId)
  {
    if(this.model.Content != null)
      return;
    var fam = famId == null ? null : await this.db.ContentFams.FirstOrDefaultAsync(item => item.Id == famId);
    this.model.Content = new() {
      Name = this.model.Name,
      Fam = fam,
      GuestPersonaAssignments = [],
      PublishedAt = this.model.PublishedAt,
    };
  }
}
