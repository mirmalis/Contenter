using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.Logging;
using Aper.Api.Services._0Brokers.Storages;

using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace Aper.Api.Services._1Foundations;
public abstract partial class AbstractFoundryService<T, TKey>
  where T : class, IIded<TKey>, IAuditable
{
  protected abstract ValueTask<T> DoUpdate(T obj);
  protected abstract ValueTask<T> DoInsert(T obj);
  protected abstract ValueTask<T?> DoSelect(TKey id);
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
  public async ValueTask<T?> GetOneById(TKey id) => await this.db.GetOneById<T, TKey>(id);
  public async ValueTask<TOut?> GetOneById<TOut>(TKey id, System.Linq.Expressions.Expression<Func<T, TOut>> selector) 
    => await this.db.GetOneById<T, TKey, TOut>(id, selector);
  
  protected IQueryable<T> GetAll() => this.db.GetAll<T>();

  public async ValueTask<IEnumerable<T>> CreateMany(IEnumerable<T> entities)
  {
    var list = new List<T>();
    foreach (var entity in entities)
    {
      var result = await this.CreateOne(entity);
      list.Add(result);
    }
    return list;
  }
  public async ValueTask<T> CreateOne(T entity) => await this.standardAddAsync(entity);
  protected ValueTask<T> standardAddAsync(T input)
  {
    return TryCatch(async () => {
      if(input is null)
        throw new Exception($"{typeof(T).Name} input is null.");
      var x = newInvalidInputException();
      ValidateInput_Common(x, input);
      ValidateInput_CreateSpecific(x, input)
        .ThrowIfContainsErrors();

      return await this.DoInsert(input);
    });
  }
  public async ValueTask<IEnumerable<T>> UpdateMany(IEnumerable<T> entities)
  {
    if (!entities.Any())
      return [];
    var list = new List<T>();
    foreach (var entity in entities)
    {
      var result = await this.UpdateOne(entity);
      list.Add(result);
    }
    return list;
  }
  public async ValueTask<T> UpdateOne(T entity) => await this.standardModifyAsync(entity);
  protected virtual T MergeForUpdating(T input, T existing)
  {
    input.CreatedDate = existing.CreatedDate;
    input.UpdatedDate = now;
    return input;
  }
  protected ValueTask<T> standardModifyAsync(T input)
  {
    return TryCatch(async () => {
      if(input is null)
        throw new Exception($"Input of {typeof(T).Name} is null.");
      T? existing = await this.DoSelect(input.Id);
      if(existing == null)
        throw new Exception($"No {typeof(T).Name} (Id={input.Id}) to update.");
      
      var x = newInvalidInputException();

      this.ValidateInput_Common(x, input);
      ValidateInput_ModifySpecific(x, input).ThrowIfContainsErrors();

      var core = this.MergeForUpdating(input, existing!);
      Validate_AgainstStorageObject(x, core, existing!)
        .ThrowIfContainsErrors();
      
      return await this.DoUpdate(core);
    });
  }

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
