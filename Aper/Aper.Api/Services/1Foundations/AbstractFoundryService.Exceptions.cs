using Aper.Api.Models;
using Aper.Models;

namespace Aper.Api.Services._1Foundations;

public partial class AbstractFoundryService<T, TKey>
{
  protected virtual Xeptions.Xeption newNullInputException() => new X_NullException<T>();
  protected virtual Xeptions.Xeption newInvalidInputException() => new X_InvalidException<T>();

  protected virtual Exception UpcastException(Exception ex)
  {
    return ex switch {
      _ => new UnknownException()
    };
  }
  protected Exception CreateAndLogCorrectException(Exception ex)
  {
    var result = this.UpcastException(ex);
    this.loggingBroker.LogError(result);
    return result;
  }
}
