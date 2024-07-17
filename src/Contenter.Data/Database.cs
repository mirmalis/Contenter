using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;

public class Database(DbContextOptions<Database> options): DbContext(options)
{
  public DbSet<Contenter.Models.Contents.Content> Contents => this.Set<Contenter.Models.Contents.Content>();
  public DbSet<Contenter.Models.Contents.ContentFam> ContentFams => this.Set<Contenter.Models.Contents.ContentFam>();
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
    #region Contents
    mb.Entity<Contenter.Models.Contents.Content>(content => {
      content.ToTable("Content");
      content.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);

    });
    mb.Entity<Contenter.Models.Contents.ContentGuests<Models.Persons.Persona>>(personaGuestAss => {

      personaGuestAss.HasKey(item => new { item.ContentId, item.GuestId });
    });
    mb.Entity<Contenter.Models.Contents.ContentSources>(sourceAss => {
      sourceAss.HasKey(item => new { item.ContentId, item.SourceId });
    });
    mb.Entity<Contenter.Models.Contents.ContentFam>(contentFam => {
      contentFam.ToTable("ContentFam");
      contentFam.Property(item => item.PayLinks).HasDefaultValue(new List<string>());
    });
    #endregion
    #region Persons
    mb.Entity<Contenter.Models.Persons.Persona>(persona => {
    });
    #endregion
    #region Sources
    mb.Entity<Contenter.Models.Sources.Source>(source => {
      source.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
      source.HasOne(item => item.Definition).WithMany(item => item.Instances)
        .HasForeignKey(item => new { item.PlatformId, item.DefinitionUid });
      source.HasOne(item => item.Platform).WithMany().HasForeignKey(item => item.PlatformId);
    });
    mb.Entity<Contenter.Models.Sources.SourcePlatform>(platform => {
    });
    mb.Entity<Contenter.Models.Sources.SourceDefinition>(sdefinition => {
      sdefinition.HasKey(sd => new { sd.PlatformId, sd.Uid });
    });
    #endregion
  }
  private static readonly string SQL_DATETIME_NOW = "datetime('now')";
}
