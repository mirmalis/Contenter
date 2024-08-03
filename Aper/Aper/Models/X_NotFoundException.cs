namespace Aper.Models;
public class X_NotFoundException<T, TKey>(TKey id): Xeptions.Xeption($"Couldn't find {typeof(T).Name} with id: {id}.")
  where T: IIded<TKey>
{
}
