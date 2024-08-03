namespace Aper.Exceptions;
public class NotFoundException<T, TKey>: Xeptions.Xeption
{
  public NotFoundException(TKey id) :
    base(message: $"Couldn't find {nameof(T)} with id: {id}.")
  { }
}
