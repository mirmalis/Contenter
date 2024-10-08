﻿namespace Aper.Api.Services._2Processing;

public interface IAbstractProcessingService<T, TKey>
  where T : class, IIded<TKey>
{
  ValueTask<T?> GetOneById(TKey id);
  ValueTask<TOut?> GetOneById<TOut>(TKey id, System.Linq.Expressions.Expression<Func<T, TOut>> selector);
  ValueTask<IEnumerable<TKey>> GetExistingIds(IEnumerable<TKey> ids);
  ValueTask<IEnumerable<T>> UpdateMany(IEnumerable<T> entities);
  ValueTask<IEnumerable<T>> CreateMany(IEnumerable<T> entities);
  ValueTask<IEnumerable<T>> CreateOrUpdateMany(IEnumerable<T> entities);
  ValueTask<IEnumerable<T>> CreateNonExsistant(IEnumerable<T> entities);
  ValueTask<T> CreateOrUpdateOne(T entity);


}
