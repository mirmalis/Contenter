namespace Aper.Api.Services._1Foundations;

public partial class AbstractFoundryService<T, TKey>
  where T: class, IIded<TKey>, IAuditable
{

  public async ValueTask<IEnumerable<T>> CreateMany(IEnumerable<T> entities)
  {
    var list = new List<T>();
    foreach(var entity in entities)
    {
      var result = await this.CreateOne(entity);
      list.Add(result);
    }
    return list;
  }
  public async ValueTask<T> CreateOne(T entity) => await this.standardAddAsync(entity);
  public async ValueTask<IEnumerable<T>> UpdateMany(IEnumerable<T> entities)
  {
    if(!entities.Any())
      return [];
    var list = new List<T>();
    foreach (var entity in entities)
    {
      entity.UpdatedDate = this.now;
      var result = await this.UpdateOne(entity);
      list.Add(result);
    }
    return list;
  }
  public async ValueTask<T> UpdateOne(T entity) => await this.standardModifyAsync(entity);
  protected void Input_ThrowIfNull(T? input)
  {
    if(input is null)
      throw newNullInputException();
  }
  protected abstract TException ValidateInput_Common<TException>(TException x, T input)
    where TException: Xeptions.Xeption
    ;
  protected abstract TException ValidateInput_CreateSpecific<TException>(TException x, T input)
    where TException : Xeptions.Xeption
    ;
  protected abstract TException ValidateInput_ModifySpecific<TException>(TException x, T input)
    where TException : Xeptions.Xeption
    ;
  protected abstract TException Validate_AgainstStorageObject<TException>(TException x, T input, T storage)
    where TException : Xeptions.Xeption
    ;
}
