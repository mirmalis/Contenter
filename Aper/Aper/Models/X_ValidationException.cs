namespace Aper.Models;
// TODO: remove T ???

public class X_ValidationException<T>(Exception innerException):
  Xeptions.Xeption(
    message: $"Invalid {typeof(T).Name} input, contact support",
    innerException)
{ }
