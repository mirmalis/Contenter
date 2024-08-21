using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;

public partial class Database(DbContextOptions<Database> options): DbContext(options)
{
  public DbSet<Contenter.Models.Contents.Content> Contents => this.Set<Contenter.Models.Contents.Content>();
  public DbSet<Contenter.Models.Contents.ContentFam> ContentFams => this.Set<Contenter.Models.Contents.ContentFam>();
  public DbSet<Contenter.Models.Contents.ContentSave> ContentSaves => this.Set<Contenter.Models.Contents.ContentSave>();
  
  public DbSet<Contenter.Models.Sources.Source> Sources => this.Set<Contenter.Models.Sources.Source>();
  public DbSet<Contenter.Models.Sources.SourcePlatform> Platforms => this.Set<Contenter.Models.Sources.SourcePlatform>();
  public DbSet<Contenter.Models.Sources.Channel> Channels => this.Set<Contenter.Models.Sources.Channel>();
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
    this.ConfigureObjectify(mb);
    #region Contents
    mb.Entity<Contenter.Models.Contents.ContentSave>(save => {
      save.ToTable("ContentSaves");
      save.HasKey(item => new { item.ContentId, item.ApplicationUserId });
      save.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
    mb.Entity<Contenter.Models.Contents.Content>(content => {
      content.ToTable("Content");
      content.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);

    });
    mb.Entity<Contenter.Models.Contents.ContentGuests<Contenter.Models.Objectify.Thing >> (personaGuestAss => {

      personaGuestAss.HasKey(item => new { item.ContentId, item.GuestId });
    });
    mb.Entity<Contenter.Models.Contents.ContentFam>(contentFam => {
      contentFam.ToTable("ContentFam");
      contentFam.HasMany(item => item.SourceChannels).WithMany(item => item.CotentFams)
        .UsingEntity<Models.Contents.ContentFamChannel>(
          l => l.HasOne(item => item.Channel).WithMany(item => item.CotentFamsAssignments),
          r => r.HasOne(item => item.ContentFam).WithMany(item => item.SourceChannelsAssignments)
        );
    });
    #endregion
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
