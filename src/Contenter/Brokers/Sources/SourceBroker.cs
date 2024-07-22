using System.Linq.Expressions;
using System.Net.Sockets;

using Contenter.Data;
using Contenter.Models.Sources;

using Microsoft.EntityFrameworkCore;

namespace Contenter.Brokers.Sources;

public class SourceBroker(Database db): ISourceBroker
{
  private readonly Contenter.Data.Database db = db;
  public IQueryable<Source> Q => this.db.Set<Source>().OrderByDescending(item => item.PublishedAt);
  public async Task<List<T>> GetListByCreationDate<T>(Expression<Func<Source, T>> expression, int max = 100, int skip = 0)
  {
    return await this.db.Set<Contenter.Models.Sources.Source>()
      .OrderByDescending(item => item.CreatedAt)
      .Skip(skip)
      .Take(max)
      .Select(expression)
      .ToListAsync();
  }

  public async Task<T?> GetOneById<T>(Expression<Func<Source, T>> expression, Guid id)
  {
    return await this.db
      .Set<Contenter.Models.Sources.Source>()
      .Where(item => item.Id == id)
      .Select(expression)
      .FirstOrDefaultAsync();
  }
  public async Task<bool> Mark_as_WontHaveContent_ById(Guid sourceId) 
    => await AddFlag(sourceId, SourceFlags.DoesntHaveContentIntentionally, true);
  public async Task<bool> Shown_at_MainPage(Guid sourceId, bool state)
    => await AddFlag(sourceId, SourceFlags.HiddenFromMain, !state);
  public async Task<bool> Set_is_Preview(Guid sourceId, bool state)
    => await AddFlag(sourceId, SourceFlags.Preview, state);

  private async Task<bool> AddFlag(Guid sourceId, SourceFlags flag, bool state)
  {
    var existing = await this.db.Sources.FirstOrDefaultAsync(item => item.Id == sourceId);
    if (existing == null)
    {
      // Bad request
      return false;
    }
    if (state)
    {
      if (existing.Flags.HasFlag(flag))
        return true;
      existing.Flags ^= flag;
    }
    else
    {
      if (!existing.Flags.HasFlag(flag))
        return true;
      existing.Flags &= ~flag;
    }
    await this.db.SaveChangesAsync();
    return true;
  }
}
