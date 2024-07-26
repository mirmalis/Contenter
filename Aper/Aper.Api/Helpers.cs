namespace Aper.Api;

public static class Helpers
{
  public static DateTime? ParseRawDateTime(this string datetimeRaw)
  {
    return DateTime.Parse(datetimeRaw).NoMS();
  }
  public static DateTime NoMS(this DateTime @this)
  {
    return new DateTime(@this.Year, @this.Month, @this.Day, @this.Hour, @this.Minute, @this.Second);
  }
  
}
