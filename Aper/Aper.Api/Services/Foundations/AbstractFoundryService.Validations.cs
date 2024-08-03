using Aper.Exceptions;

namespace Aper.Api.Services.Foundations;

public partial class AbstractFoundryService<T, TKey>
{
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
