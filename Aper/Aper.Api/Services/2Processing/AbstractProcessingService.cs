using Aper.Api.Services._1Foundations;
using Aper.Models.Channels;

namespace Aper.Api.Services._2Processing;

public abstract class AbstractProcessingService<T, TKey, TFoundationService>
  where T : class, IIded<TKey>
  where TFoundationService : IAbstractFoundationService<T, TKey>
{
  public virtual async ValueTask<T?> GetOneById(TKey id)
    => await this.service.GetOneById(id);
  public virtual async ValueTask<TOut?> GetOneById<TOut>(TKey id, System.Linq.Expressions.Expression<Func<T, TOut>> selector)
    => await this.service.GetOneById(id, selector);
  public async ValueTask<IEnumerable<TKey>> GetExistingIds(IEnumerable<TKey> ids)
    => await this.service.GetExistingIds(ids);
  public async ValueTask<IEnumerable<T>> UpdateMany(IEnumerable<T> entities)
    => await this.service.UpdateMany(entities);
  public async ValueTask<IEnumerable<T>> CreateMany(IEnumerable<T> entities)
    => await this.service.CreateMany(entities);
  #region Constructors
  protected TFoundationService service { get; }
  protected AbstractProcessingService(TFoundationService service)
  {
    this.service = service;
  }
  #endregion
  public virtual async ValueTask<IEnumerable<T>> CreateOrUpdateMany(IEnumerable<T> entities)
  {
    entities = entities.DistinctBy(item => item.Id);
    var existingIds = await this.GetExistingIds(entities.Select(video => video.Id));
    var existingInputs = entities.Where(item => existingIds.Contains(item.Id));
    var newInputs = entities.Where(item => !existingIds.Contains(item.Id));

    var updated = await this.UpdateMany(existingInputs);
    var created = await this.CreateMany(newInputs);

    return [.. updated, .. created];
  }
  public virtual async ValueTask<T> CreateOrUpdateOne(T entity)
  {
    if (entity is null)
      throw new Exception();

    var existingIds = await this.service.GetExistingIds([entity.Id]);

    return existingIds.Any()
      ? await this.service.UpdateOne(entity)
      : await this.service.CreateOne(entity)
      ;
  }
}
