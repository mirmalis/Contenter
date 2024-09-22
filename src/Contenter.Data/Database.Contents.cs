using Contenter.Models.Contents;

using Microsoft.EntityFrameworkCore;

namespace Contenter.Data;
public partial class Database
{
  public DbSet<Content> Contents => this.Set<Content>();
  public DbSet<ContentDefinition> ContentDefinitions => this.Set<ContentDefinition>();
  public DbSet<ContentFam> ContentFams => this.Set<ContentFam>();
  public DbSet<ContentSave> ContentSaves => this.Set<ContentSave>();
  private void ConfigureContents(ModelBuilder mb)
  {
    mb.Entity<ContentDefinition>(cd => {
      cd.ToTable("ContentDefinitions");
    });
    mb.Entity<Content>(content => {
      content.ToTable("Content");
      content.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
      content.HasMany(item => item.Slots).WithMany()
        .UsingEntity<Content_ContentSlot>(
          l => l.HasOne(item => item.Slot).WithMany(item => item.ContentAssignments),
          r => r.HasOne(item => item.Content).WithMany(item => item.SlotAssignments)
        );
    });
    mb.Entity<Slot>(slot => {
      slot.ToTable("ContentSlots");
    });
    mb.Entity<Content_ContentSlot>(slotAss => {
      slotAss.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
      slotAss.ToTable("Content_ContentSlot");
    });
    mb.Entity<ContentGuests<Models.Objectify.Thing>>(thingAss => {
      thingAss.ToTable("ContentGuests<Thing>");
      thingAss.HasKey(item => new { item.ContentId, item.GuestId });
      thingAss.HasOne(item => item.SlotAss).WithMany(item => item.ThingAssignments)
        .HasForeignKey(item => new { item.SlotId, item.ContentId })
        .HasPrincipalKey(item => new {item.SlotId, item.ContentId });
      thingAss.HasOne(item => item.Slot).WithMany()
        .HasForeignKey(item => item.SlotId)
        .HasPrincipalKey(item => item.Id);
    });
    mb.Entity<ContentFam>(contentFam => {
      contentFam.ToTable("ContentFam");
      contentFam.HasMany(item => item.SourceChannels).WithMany(item => item.CotentFams)
        .UsingEntity<Models.Contents.ContentFamChannel>(
          l => l.HasOne(item => item.Channel).WithMany(item => item.CotentFamsAssignments),
          r => r.HasOne(item => item.ContentFam).WithMany(item => item.SourceChannelsAssignments)
        );
    });

    // used
    mb.Entity<ContentSave>(save => {
      save.ToTable("ContentSaves");
      save.HasKey(item => new { item.ContentId, item.ApplicationUserId });
      save.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
  }
}
