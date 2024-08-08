namespace Aper.Api.Services._1Foundations;

public interface IAbstractFoundationService<T, TKey>
  where T : class, IIded<TKey>
{
  ValueTask<T?> GetOneById(TKey id);
  ValueTask<TOut?> GetOneById<TOut>(TKey id, System.Linq.Expressions.Expression<Func<T, TOut>> selector);
  
  ValueTask<IEnumerable<TKey>> GetExistingIds(IEnumerable<TKey> ids);
  ValueTask<T> CreateOne(T entity);
  ValueTask<IEnumerable<T>> CreateMany(IEnumerable<T> entities);
  ValueTask<T> UpdateOne(T entity);
  ValueTask<IEnumerable<T>> UpdateMany(IEnumerable<T> entities);
}
