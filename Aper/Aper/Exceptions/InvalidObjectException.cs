namespace Aper.Exceptions;
public class InvalidObjectException<T>: Xeptions.Xeption
{
  public InvalidObjectException() :
    base(message: $"Invalid {typeof(T).Name}. Please fix the errors and try again.")
  { }
  public InvalidObjectException(string parameterName, object parameterValue) :
    base(message: $"Invalid {typeof(T).Name}, parameter name: {parameterName}, parameter value: {parameterValue}.")
  { }
}
