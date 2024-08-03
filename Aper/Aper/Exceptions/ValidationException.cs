namespace Aper.Exceptions;
public class ValidationException<T>: Xeptions.Xeption
{
    public ValidationException(Exception innerException)
        : base(message: $"Invalid input {nameof(T)}, contact support.", innerException) { }
}
