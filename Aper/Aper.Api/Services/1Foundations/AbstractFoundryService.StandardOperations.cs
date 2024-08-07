namespace Aper.Api.Services._1Foundations;

public partial class AbstractFoundryService<T, TKey>
{
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
      input.CreatedDate = core!.CreatedDate;
      return await this.DoUpdate(input);
    });
  }
}

