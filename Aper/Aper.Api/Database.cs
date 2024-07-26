using Aper.Models;
using Aper.Models.Videos;

using Microsoft.EntityFrameworkCore;

namespace Aper.Api;

public class Database(DbContextOptions<Database> options): DbContext(options)
{
  public DbSet<Video> Videos => this.Set<Video>();
  public DbSet<Channel> Channels => this.Set<Channel>();
  public DbSet<Playlist> Playlists => this.Set<Playlist>();
  public DbSet<PlaylistItem> PlaylistItems => this.Set<PlaylistItem>();

  protected override void OnModelCreating(ModelBuilder mb)
  {
    base.OnModelCreating(mb);
    mb.Entity<Channel>(channel => {
      channel.ToTable("Channel");
      channel.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
    mb.Entity<Video>(videos => {
      videos.ToTable("Video");
      videos.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
    mb.Entity<Playlist>(playlists => {
      playlists.ToTable("Playlist");
      playlists.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
    mb.Entity<PlaylistItem>(playlistItems => {
      playlistItems.ToTable("PlaylistItems");
      playlistItems.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
    });
    mb.Entity<VideoField>(videoFields => {
      videoFields.HasKey(item => new { item.VideoId, item.Field });
      videoFields.Property(item => item.CreatedAt).HasDefaultValueSql(SQL_DATETIME_NOW);
      videoFields.HasOne(item => item.Video).WithMany(item => item.Fields)
        .HasForeignKey(item => item.VideoId)
        .HasPrincipalKey(item => item.Id);
      videoFields.HasMany(item => item.Changes).WithOne(item => item.Field)
        .HasForeignKey(item => new { item.VideoFieldVideoId, item.VideoField })
        .HasPrincipalKey(item => new { item.VideoId, item.Field });
    });
    mb.Entity<Models.Videos.VideoFieldChange>(videoFieldsChange => {

    });
  }
  private const string SQL_DATETIME_NOW = "DateTime('now')";
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => base.OnConfiguring(optionsBuilder);
}
