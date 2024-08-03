namespace Aper.Api.Brokers.DateTimes;

public interface IDateTimeBroker
{
  DateTimeOffset GetCurrentDateTime();
}
