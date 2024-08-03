namespace Aper;
public interface IAuditable
{
  DateTimeOffset CreatedDate { get; set; }
  DateTimeOffset UpdatedDate { get; set; }
}
