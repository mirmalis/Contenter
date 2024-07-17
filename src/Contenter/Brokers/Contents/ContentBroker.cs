using Contenter.Data;

using Microsoft.EntityFrameworkCore;

namespace Contenter.Brokers.Contents;

public class ContentBroker: IContentBroker
{

  #region Constructors
  private readonly Database db;

  public ContentBroker(Contenter.Data.Database db)
  {
    this.db = db;
  }
  #endregion
  
  public async Task<List<T>> GetLatestContents<T>(System.Linq.Expressions.Expression<Func<Contenter.Models.Contents.Content, T>> expression,  int max = 100, int skip = 0)
  {
    return await this.db
      .Contents
      .OrderByDescending(item => item.CreatedAt)
      .Skip(skip)
      .Take(max)
      .Select(expression)
      .ToListAsync();
  }
}
