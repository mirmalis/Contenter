using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aper.Api.Brokers.Storages;

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
  #endregion

  private async ValueTask<T> InsertAsync<T>(T @object)
    where T : class
  {
    this.Entry(@object).State = EntityState.Added;
    await this.SaveChangesAsync();

    return @object;
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

  private async ValueTask<T> DeleteAsync<T>(T @object)
    where T : class
  {
    this.Entry(@object).State = EntityState.Deleted;
    await this.SaveChangesAsync();

    return @object;
  }

  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
    ConfigChannels(mb);
    ConfigChannelSnippet(mb);
    ConfigVideos(mb);
    ConfigPlaylist(mb);
    ConfigPlaylistItems(mb);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    string connectionString = this.configuration.GetConnectionString("Aper") ?? throw new NullReferenceException("Failed to get connection string");
    optionsBuilder.UseSqlite(connectionString);
  }
}
