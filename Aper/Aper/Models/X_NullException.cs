namespace Aper.Models;
public class NullException(string message): 
  Xeptions.Xeption(message: message)
  {}
public class X_NullException<T>():
  NullException(message: $"The {typeof(T).Name} is null.")
  {}
