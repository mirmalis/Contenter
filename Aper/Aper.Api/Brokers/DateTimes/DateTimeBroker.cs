namespace Aper.Api.Brokers.DateTimes;
using Aper.Api;

public class DateTimeBroker: IDateTimeBroker
{
  public DateTimeOffset GetCurrentDateTime() => DateTimeOffset.UtcNow;
  public DateTime Now() => DateTime.UtcNow.NoMS();
}
