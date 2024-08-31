using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;
public partial class Database: IStorageBroker
{
  public async Task CreateOrUpdateMany(IEnumerable<Models.Sources.Source> sources)
  {
    var existingHrefs = await this.Set<Models.Sources.Source>()
      .Where(item => sources.Select(s => s.Href).Contains(item.Href))
      .Select(item => item.Href)
      .ToListAsync()
    ;

    var existingSources = sources.Where(s => existingHrefs.Contains(s.Href));
    var newSources = sources.Where(s => !existingHrefs.Contains(s.Href));

    await this.CreateMany(newSources);
    await this.UpdateMany(existingSources);
    await this.SaveChangesAsync();
  }
  private async Task<IEnumerable<Models.Sources.Source>> CreateMany(IEnumerable<Models.Sources.Source> sources)
  {
    if (sources.Any())
    {
      this.Set<Models.Sources.Source>().AddRange(sources);
    }

    return sources;
  }
  private async Task<IEnumerable<Models.Sources.Source>> UpdateMany(IEnumerable<Models.Sources.Source> sources)
  {
    if (sources.Any())
    {
      // TODO: implement update

    }

    return sources;
  }


  public async Task MarkChannelAsFullScrapedAt(Guid channelId, DateTimeOffset at)
  {
    var existing = await this.Set<Models.Sources.Channel>().FindAsync(channelId);
    if (existing is null) 
      throw new Exception("Channel doesnt exist");
    existing.FullScrapedAt = at;
    await this.SaveChangesAsync();
  }
}
