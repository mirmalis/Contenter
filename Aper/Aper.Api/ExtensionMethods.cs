using Aper.Models;

namespace Aper.Api;

public static class ExtensionMethods
{
  public static DateTime WithoutMiliseconds(this DateTime @this)
  {
    return @this.AddMilliseconds(-@this.Millisecond);
  }

  
}
