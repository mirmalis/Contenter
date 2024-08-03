using Aper.Api.Brokers.DateTimes;
using Aper.Api.Brokers.Logging;

namespace Aper.Api.Services.Foundations;

public partial class AbstractFoundryService<T, TKey>
{
  #region Constructors
  protected string TName => typeof(T).Name;
  protected AbstractFoundryService(ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
  {
    this.loggingBroker = loggingBroker;
    this.dateTimeBroker = dateTimeBroker;
  }
  protected ILoggingBroker loggingBroker { get; }
  protected IDateTimeBroker dateTimeBroker { get; }
  #endregion

  protected abstract ValueTask<T> DoUpdate(T obj);
  protected abstract ValueTask<T> DoInsert(T obj);
  protected abstract ValueTask<T?> DoSelect(TKey id);
}
