namespace Aper.Models;
public class X_InvalidException<T>: Xeptions.Xeption
{
	#region Constructors
	public X_InvalidException(string parameterName, object parameterValue):
		base(message: $"Invalid {typeof(T).Name}, parameter name: {parameterName}, parameter value: {parameterValue}.")
		{ }
  public X_InvalidException():
		base(message: $"Invalid {typeof(T).Name}. Please fix the errors and try again.")
		{ }
	#endregion
}
