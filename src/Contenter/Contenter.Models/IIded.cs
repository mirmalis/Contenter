namespace Contenter;

public interface IIded<TKey>
{
  public TKey Id { get; set; }
}
public class Ided: IIded<Guid>
{
  public Guid Id { get; set; }
}
