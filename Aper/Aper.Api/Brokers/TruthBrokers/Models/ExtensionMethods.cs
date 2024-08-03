using Aper.Models.Channels;
using Aper.Models.PlaylistItems;
using Aper.Models.Playlists;
using Aper.Models.Videos;

namespace Aper.Api.Brokers.TruthBrokers.Models;
public static class ExtensionMethods
{
  public static Aper.Models.AccessStates Convert(this PrivacyStatuses privacyStatus)
    => privacyStatus switch {
      PrivacyStatuses._private => Aper.Models.AccessStates._private,
      PrivacyStatuses._unlisted => Aper.Models.AccessStates._unlisted,
      PrivacyStatuses._public => Aper.Models.AccessStates._public,
      _ => throw new NotImplementedException()
    };
public static Channel Merge(this ChannelDetails data, Channel? existing, DateTimeOffset? now = null)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedDate = _now,
    };
    existing.UpdatedDate = _now;

    existing.Id = data.Id;
    existing.Handle = data.Handle;
    existing.Title = data.Title;
    existing.UploadsPlaylistId = data.UploadsPlaylist;
    existing.PublishedAt = data.PublishedAt;
    existing.Country = data.Country;

    return existing;
  }
  public static Channel Merge(this BasicChannelInfo data, Channel? existing, DateTimeOffset? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedDate = _now,
    };
    existing.UpdatedDate = _now;

    existing.Id = data.Id;
    existing.Title = data.Title;

    return existing;
  }
  public static Video Merge(this VideoDetails data, Video? existing, DateTimeOffset? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedDate = _now,
    };
    existing.UpdatedDate = _now;

    existing.Id = data.Id;
    existing.PublishedAt = data.PublishedAt;
    existing.Title = data.Title;
    existing.Description = data.Description;
    existing.Channel = data.Channel.Merge(null, _now);
    existing.ChannelId = data.Channel.Id;

    return existing;
  }

  public static Video Merge(this BasicVideoInfo data, Video? existing, DateTimeOffset? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedDate = _now,
    };
    existing.UpdatedDate = _now;

    existing.Id = data.Id;
    existing.PublishedAt = data.PublishedAt;
    existing.ChannelId = data.Channel.Id;
    existing.Title = data.Title;
    existing.Description = data.Description;
    existing.PrivacyStatus = data.PrivacyStatus?.Convert();

    return existing;
  }
  public static Playlist Merge(this PlaylistDetails data, Playlist? existing, Channel? channel, DateTimeOffset? now = null)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedDate = _now,
    };
    existing.UpdatedDate = _now;

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
    existing.PrivacyStatus = data.PrivacyStatus?.Convert() ;

    return existing;
  }
  public static PlaylistItem Merge(this PlaylistItemDetails data, PlaylistItem? existing, DateTimeOffset? now)
  {
    var _now = now ?? DateTime.UtcNow.NoMS();
    existing ??= new() {
      CreatedDate = _now,
    };
    existing.UpdatedDate = _now;

    existing.Id = data.Id;
    existing.PublishedAt = data.PublishedAt;
    existing.Position = data.Position;
    existing.PlaylistId = data.Playlist.Id;
    existing.VideoId = data.Video.Id;
    existing.ChannelId = data.Channel.Id;

    return existing;
  }
}
