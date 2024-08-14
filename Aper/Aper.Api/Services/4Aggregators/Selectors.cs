namespace Aper.Api.Services._4Aggregators;

internal static class Selectors
{
  public static Func<Aper.Models.Videos.Video, object> videoSelector = video => new {
    video.PublishedAt,
    Channel = new {
      Id = video.ChannelId,
    },
    video.Id,
    video.Title,
    Privacy = new {
      Accessible = video.PrivacyStatus!.Value.HasFlag(Aper.Models.AccessStates._accessible),
      Listed = video.PrivacyStatus!.Value.HasFlag(Aper.Models.AccessStates._listed)
    }
  };
}
