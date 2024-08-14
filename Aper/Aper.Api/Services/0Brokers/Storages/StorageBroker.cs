using System.Collections.Immutable;

using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Services._0Brokers.Storages;

public partial class StorageBroker: DbContext, IStorageBroker
{
  #region Constructors
  private const string SQL_DATETIME_NOW = "DateTime('now')";
  private readonly IConfiguration configuration;
  public StorageBroker(IConfiguration configuration)
  {
    this.configuration = configuration;
    this.Database.Migrate();
  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    string connectionString = this.configuration.GetConnectionString("Aper")
      ?? throw new NullReferenceException("Failed to get connection string");
    optionsBuilder.UseSqlite(connectionString);
  }
  #endregion
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
    ConfigChannels(mb);
    ConfigChannelSnippet(mb);
    ConfigVideos(mb);
    ConfigPlaylist(mb);
    ConfigPlaylistItems(mb);
  }
  public async ValueTask<T?> GetOneById<T, TKey>(TKey id)
    where T : class, IIded<TKey>
  {
    return await this.Set<T>().Where(item => item.Id!.Equals(id)).FirstOrDefaultAsync();
  }
  public async ValueTask<IEnumerable<T>> GetManyByIds<T, TKey>(IEnumerable<TKey> ids)
    where T : class, IIded<TKey>
  {
    return await this.Set<T>().Where(item => ids.Contains(item.Id)).ToListAsync();
  }
  public async ValueTask<TOut?> GetOneById<T, TKey, TOut>(TKey id, System.Linq.Expressions.Expression<Func<T, TOut>> selector)
    where T : class, IIded<TKey>
  {
    return await this.Set<T>()
      .Where(item => item.Id!.Equals(id))
      .Select(selector)
      .FirstOrDefaultAsync();
  }
  public IQueryable<T> GetAll<T>()
    where T : class
  {
    return this.Set<T>();
  }

  public async ValueTask<T> InsertAsync<T>(T @object)
    where T : class
  {
    this.Entry(@object).State = EntityState.Added;
    await this.SaveChangesAsync();

    return @object;
  }
  private async ValueTask<IEnumerable<T>> InsertManyNewAsync<T, TKey>(IEnumerable<T> xs)
    where T : class, IIded<TKey>
  {
    var exIds = await this.Set<T>()
      .Where(item => xs.Select(x => x.Id).Contains(item.Id))
      .Select(item => item.Id)
      .ToListAsync();
    var newXs = xs.Where(x => !exIds.Contains(x.Id));
    this.Set<T>().AddRange(newXs);
    await this.SaveChangesAsync();

    return newXs;
  }
  private IQueryable<T> SelectAll<T>()
    where T : class
  {
    return this.Set<T>();
  }
  private async ValueTask<T?> SelectAsync<T>(params object[] @objectIds)
    where T : class
  {
    return await this.FindAsync<T>(objectIds);

  }
  private async ValueTask<T> UpdateAsync<T>(T @object)
    where T : class
  {
    this.Entry(@object).State = EntityState.Modified;
    await this.SaveChangesAsync();

    return @object;
  }
  public async ValueTask<IEnumerable<T>> UpdateManyAsync<T>(IEnumerable<T> objects)
    where T : class
  {
    foreach(var obj in objects)
    {
      this.Update(obj);
      //this.Entry(obj).State = EntityState.Modified;
    }
    await this.SaveChangesAsync();

    return objects;
  }


  private async ValueTask<T> DeleteAsync<T>(T @object)
    where T : class
  {
    this.Entry(@object).State = EntityState.Deleted;
    await this.SaveChangesAsync();

    return @object;
  }
}
