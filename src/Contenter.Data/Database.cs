

using Contenter.Models.Sources;

using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;

public partial class Database(DbContextOptions<Database> options): DbContext(options), IStorageBroker
{
  
  
  public DbSet<Contenter.Models.Sources.Source> Sources => this.Set<Contenter.Models.Sources.Source>();
  public DbSet<Contenter.Models.Sources.SourcePlatform> Platforms => this.Set<Contenter.Models.Sources.SourcePlatform>();
  public DbSet<Contenter.Models.Sources.Channel> Channels => this.Set<Contenter.Models.Sources.Channel>();
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
    this.ConfigureContents(mb);
    this.ConfigureObjectify(mb);
    #region Sources
    mb.Entity<Contenter.Models.Sources.Source>(source => {
      source.ToTable("Source");
      source.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
      source.HasOne(item => item.Channel).WithMany(item => item.Sources)
        .HasForeignKey(item => new { item.PlatformId, item.ChannelUid })
        .HasPrincipalKey(item => new { item.PlatformId, item.Uid });
      source.HasOne(item => item.Definition).WithMany(item => item.Instances)
        .HasForeignKey(item => new { item.PlatformId, item.DefinitionUid });
      source.HasOne(item => item.Platform).WithMany().HasForeignKey(item => item.PlatformId);
    });
    mb.Entity<Contenter.Models.Sources.Channel>(channel => {
      channel.ToTable("SourceChannel");
      channel.HasAlternateKey(item => new { item.PlatformId, item.Uid });
    });
    mb.Entity<Contenter.Models.Sources.SourcePlatform>(platform => {
      platform.ToTable($"SourcePlatform");
    });
    mb.Entity<Contenter.Models.Sources.SourceDefinition>(sdefinition => {
      sdefinition.HasKey(sd => new { sd.PlatformId, sd.Uid });
    });
    #endregion
  }
  private static readonly string SQL_DATETIME_NOW = "datetime('now')";

  
}
