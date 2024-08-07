using Aper.Exceptions;

namespace Aper.Api.Services._1Foundations;

internal static class Validators
{
  public static TException AddInvalid<TException>(this TException @this, params InvalidIf[] validations)
    where TException: Xeptions.Xeption
  {
    foreach (InvalidIf rule in validations)
    {
      if (rule.Condition)
      {
        @this.UpsertDataList(key: rule.ParameterName, value: rule.Message);
      }
    }
    return @this;
  }

  public static void Validate<T>(params InvalidIf[] validations)
  {
    var invalidObjectException = new InvalidObjectException<T>();

    foreach (InvalidIf rule in validations)
    {
      if (rule.Condition)
      {
        invalidObjectException.UpsertDataList(key: rule.ParameterName, value: rule.Message);
      }
    }
    invalidObjectException.ThrowIfContainsErrors();
  }
}
