using Aper.Api.Brokers.Models;

namespace Aper.Api.Brokers;

public static class Helpers
{
  public static PrivacyStatuses ToPrivacyStatus(this string statusName)
  {
    return statusName switch {
      "public" => PrivacyStatuses._public,
      "private" => PrivacyStatuses._private,
      "unlisted" => PrivacyStatuses._unlisted,
      _ => throw new NotImplementedException()
    };
  }
}
