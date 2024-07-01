using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;

public class Database(DbContextOptions<Database> options): DbContext(options)
{
  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
    #region Contents
    mb.Entity<Contenter.Models.Contents.Content>(content => {
      content.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);

    });
    mb.Entity<Contenter.Models.Contents.ContentGuests<Models.Persons.Persona>>(personaGuestAss => {
      personaGuestAss.HasKey(item => new { item.ContentId, item.GuestId });
      personaGuestAss.HasAlternateKey(item => new { item.ContentId, item.Index });
    });
    mb.Entity<Contenter.Models.Contents.ContentSources>(sourceAss => {
      sourceAss.HasKey(item => new { item.ContentId, item.SourceId });
      sourceAss.HasAlternateKey(item => new { item.ContentId, item.Index });
    });
    #endregion
    #region Persons
    mb.Entity<Contenter.Models.Persons.Persona>(persona => {
    });
    #endregion
    #region Sources
    mb.Entity<Contenter.Models.Sources.SourcePlatform>(platform => {
    });
    mb.Entity<Contenter.Models.Sources.SourceDefinition>(sdefinition => {
      sdefinition.HasKey(sd => new { sd.PlatformId, sd.Uid });
    });
    mb.Entity<Contenter.Models.Sources.Source>(source => {
      source.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
      source.HasOne(item => item.Definition).WithMany(item => item.Instances)
        .HasForeignKey(item => new { item.PlatformId, item.DefinitionUid });
      source.HasOne(item => item.Platform).WithMany().HasForeignKey(item => item.PlatformId);
    });
    #endregion
  }
  private static readonly string SQL_DATETIME_NOW = "datetime('now')";
}
