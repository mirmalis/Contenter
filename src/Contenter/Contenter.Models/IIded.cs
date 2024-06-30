namespace Contenter.Models;

public interface IIded<TKey>
{
  public TKey Id { get; set; }
}
