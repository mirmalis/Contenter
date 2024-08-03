namespace Aper.Api.Services.Foundations;
public abstract partial class AbstractFoundryService<T, TKey>
  where T : class, IIded<TKey>
{
  protected async ValueTask<T> TryCatch(Func<ValueTask<T>> itemFunc)
  {
    try
    {
      return await itemFunc();
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
  
  protected ValueTask<T> standardAddAsync(T input)
  {
    return TryCatch(async () => {
      Input_ThrowIfNull(input);
      var x = newInvalidInputException();
      ValidateInput_Common(x, input);
      ValidateInput_CreateSpecific(x, input)
        .ThrowIfContainsErrors();

      return await this.DoInsert(input);
    });
  }
  protected ValueTask<T> standardModifyAsync(T input)
  {
    return TryCatch(async () => {
      this.Input_ThrowIfNull(input);
      var x = newInvalidInputException();

      this.ValidateInput_Common(x, input);
      ValidateInput_ModifySpecific(x, input)
        .ThrowIfContainsErrors();

      T? core = await this.DoSelect(input.Id);
      
      Validate_AgainstStorageObject(x, input, core!)
        .ThrowIfContainsErrors();

      return await this.DoUpdate(input);
    });
  }
}
