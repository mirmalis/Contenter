namespace Aper.Api.Services._1Foundations;

public partial class AbstractFoundryService<T, TKey>
  where T : class, IIded<TKey>, IAuditable
{
  protected abstract TException ValidateInput_Common<TException>(TException x, T input)
    where TException : Xeptions.Xeption;

  protected abstract TException ValidateInput_CreateSpecific<TException>(TException x, T input)
    where TException : Xeptions.Xeption;

  protected abstract TException ValidateInput_ModifySpecific<TException>(TException x, T input)
    where TException : Xeptions.Xeption;

  protected abstract TException Validate_AgainstStorageObject<TException>(TException x, T input, T storage)
    where TException : Xeptions.Xeption;
}
