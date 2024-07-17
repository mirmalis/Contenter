using Contenter.Data;

using Microsoft.EntityFrameworkCore;

namespace Contenter.Brokers.Contents;

public class ContentBroker(Contenter.Data.Database db): IContentBroker
{
  private readonly Database db = db;

  public async Task<List<T>> GetLatestContents<T>(System.Linq.Expressions.Expression<Func<Contenter.Models.Contents.Content, T>> expression, int max = 100, int skip = 0)
  {
    return await this.db
      .Contents
      .Where(item => !item.Flags.HasFlag(Models.Contents.ContentFlags.NotAtMain))
      .OrderByDescending(item => item.CreatedAt)
      .Skip(skip)
      .Take(max)
      .Select(expression)
      .ToListAsync();
  }

  public async Task<bool> ChangeMainPageListingStatus(Guid id, bool remove)
    => await this.ChangeFlag(id, !remove, Models.Contents.ContentFlags.NotAtMain);
  private async Task<bool> ChangeFlag(Guid id, bool status, Contenter.Models.Contents.ContentFlags flag)
  {
    var existing = await this.db.Contents.FirstOrDefaultAsync(item => item.Id == id);
    if (existing == null)
      return false;
    var nowIsListed = !existing.Flags.HasFlag(flag);
    if (nowIsListed && status || !nowIsListed && !status)
      return true;
    if (status)
    {
      existing.Flags &= flag;
    }
    else
    {
      existing.Flags ^= flag;
    }
    await this.db.SaveChangesAsync();
    return true;
  }
}
