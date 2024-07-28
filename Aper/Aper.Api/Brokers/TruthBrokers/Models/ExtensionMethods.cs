namespace Aper.Api.Brokers.TruthBrokers.Models;
public static class ExtensionMethods
{
  public static Aper.Models.Channel Merge(this ChannelDetails data, Aper.Models.Channel? existing, DateTime? now = null)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedAt = _now,
    };
    existing.UpdatedAt = _now;

    existing.Id = data.Id;
    existing.Handle = data.Handle;
    existing.Title = data.Title;
    existing.UploadsPlaylistId = data.UploadsPlaylist;
    existing.PublishedAt = data.PublishedAt;
    existing.Country = data.Country;

    return existing;
  }
  public static Aper.Models.Channel Merge(this BasicChannelInfo data, Aper.Models.Channel? existing, DateTime? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedAt = _now,
    };
    existing.UpdatedAt = _now;

    existing.Id = data.Id;
    existing.Title = data.Title;

    return existing;
  }
  public static Aper.Models.Video Merge(this VideoDetails data, Aper.Models.Video? existing, DateTime? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedAt = _now,
    };
    existing.UpdatedAt = _now;

    existing.Id = data.Id;
    existing.PublishedAt = data.PublishedAt;
    existing.Title = data.Title;
    existing.Description = data.Description;
    existing.Channel = data.Channel.Merge(null, _now);

    return existing;
  }
  public static Aper.Models.Video Merge(this BasicVideoInfo data, Aper.Models.Video? existing, DateTime? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedAt = _now,
    };
    existing.UpdatedAt = _now;

    existing.Id = data.Id;
    existing.PublishedAt = data.PublishedAt;
    existing.ChannelId = data.Channel.Id;
    existing.Title = data.Title;
    existing.Description = data.Description;

    return existing;
  }
  public static Aper.Models.Playlist Merge(this PlaylistDetails data, Aper.Models.Playlist? existing, Aper.Models.Channel? channel, DateTime? now = null)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedAt = _now,
    };
    existing.UpdatedAt = _now;

    existing.Id = data.Id;
    existing.Title = data.Title;
    existing.Description = data.Description;
    existing.PublishedAt = data.PublishedAt;

    //existing.ChannelId = null!; // Channel is set above
    if (channel == null)
    {
      existing.ChannelId = data.Channel.Id;
    }
    else
    {
      existing.Channel = channel;
    }

    existing.CurrentItemsCount = data.CurrentItemsCount;
    existing.PrivacyStatus = data.PrivacyStatus switch {
      PrivacyStatuses._private => Aper.Models.AccessStates._private,
      PrivacyStatuses._unlisted => Aper.Models.AccessStates._unlisted,
      PrivacyStatuses._public => Aper.Models.AccessStates._public,
      _ => throw new NotImplementedException()
    };

    return existing;
  }
  public static Aper.Models.PlaylistItem Merge(this PlaylistItemDetails data, Aper.Models.PlaylistItem? existing, DateTime? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedAt = _now,
    };
    existing.UpdatedAt = _now;

    existing.Id = data.Id;
    existing.PublishedAt = data.PublishedAt;
    existing.Position = data.Position;
    existing.PlaylistId = data.Playlist.Id;
    existing.VideoId = data.Video.Id;

    return existing;
  }
}
