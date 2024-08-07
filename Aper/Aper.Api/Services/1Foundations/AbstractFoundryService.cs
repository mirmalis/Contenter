using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.Logging;
using Aper.Api.Services._0Brokers.Storages;

using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Services._1Foundations;
public abstract partial class AbstractFoundryService<T, TKey>
  where T : class, IIded<TKey>, IAuditable
{
  #region Constructors
  protected string TName => typeof(T).Name;
  protected AbstractFoundryService(IStorageBroker storageBroker, ILoggingBroker loggingBroker, IDateTimeBroker dateTimeBroker)
  {
    this.db = storageBroker;
    this.loggingBroker = loggingBroker;
    this.now = dateTimeBroker.GetCurrentDateTime();
  }
  protected DateTimeOffset now { get; }
  protected IStorageBroker db { get; }
  protected ILoggingBroker loggingBroker { get; }
  #endregion

  public async ValueTask<T?> GetOneById(TKey id) => await this.db.GetOne<T, TKey>(id);
  protected IQueryable<T> GetAll() => this.db.GetAll<T>();
  protected abstract ValueTask<T> DoUpdate(T obj);
  protected abstract ValueTask<T> DoInsert(T obj);
  protected abstract ValueTask<T?> DoSelect(TKey id);

  protected async ValueTask<T> TryCatch(Func<ValueTask<T>> itemFunc)
  {
    try
    {
      var result = await itemFunc();
      return result;
    } catch (Exception ex) {
      throw /*this.CreateAndLogCorrectException(ex)*/;
    }
  }
  protected async ValueTask<IQueryable<T>> TryCatch(Func<ValueTask<IQueryable<T>>> itemsFunc)
  {
    try
    {
      return await itemsFunc();
    }
    catch (Exception ex)
    {
      throw /*this.CreateAndLogCorrectException(ex)*/;
    }
  }
  public async ValueTask<IEnumerable<TKey>> GetExistingIds(IEnumerable<TKey> ids)
  {
    var result = await this.GetAll()
      .Where(item => ids.Contains(item.Id))
      .Select(item => item.Id)
      .ToListAsync();
    return result;
  }
}
