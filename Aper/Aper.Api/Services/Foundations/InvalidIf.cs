namespace Aper.Api.Services.Foundations;

public record class InvalidIf(bool Condition, string ParameterName, string Message)
{
  //public (InvalidIf Rule, string Parameter) ForParameter(string parameter) => (this, parameter);

  private static InvalidIf isDefault(string text, string parameterName, string? message)
    => new(String.IsNullOrWhiteSpace(text), parameterName, message ?? "required");
  private static InvalidIf isDefault<T>(T obj, string parameterName, string? message)
    => new(obj == null || obj.Equals(default(T)), parameterName, message ?? "required");
  private static InvalidIf isSame<T>(T obj1, T obj2, string parameterName, string? message)
    => new((obj1 is null && obj2 is null)||(obj1 is not null && obj2 is not null && obj1.Equals(obj2))
  , parameterName, message ?? "must match");
  private static InvalidIf isDiferent<T>(T obj1, string parameterName, T obj2, string message)
    => new((obj1 is null ^ obj2 is null) || (obj1!.Equals(obj2!))
  , parameterName, message);

  //private static InvalidIf isDefault(Guid id, string message, string parameterName) => new(id == default, message, parameterName);
  public static InvalidIf IsDefault(string value, string parameterName, string? message = null) 
    => isDefault(value, parameterName, message);
  public static InvalidIf IsDefault(DateTimeOffset value, string parameterName, string? message = null) 
    => isDefault(value, parameterName, message);
  public static InvalidIf InvalidId(Guid id, string parameterName, string? message = null) 
    => isDefault(id, parameterName, message);
  public static InvalidIf InvalidId(string id, string parameterName, string? message = null)
    => isDefault(id, parameterName, message);
  public static InvalidIf IdDiferent(Guid firstId, string parameterName, Guid secondId, string secondIdName)
    => isDiferent(firstId, parameterName, secondId, $"must match with {secondIdName}");
  public static InvalidIf IdDiferent(string firstId, string parameterName, string secondId, string secondIdName)
    => isDiferent(firstId, parameterName, secondId, $"must match with {secondIdName}");

  public static InvalidIf IsDiferent(DateTimeOffset firstDate, string parameterName, DateTimeOffset secondDate, string secondDateName)
    => new InvalidIf(firstDate != secondDate, parameterName, $"must match with {secondDateName}");
  public static InvalidIf IsSame(DateTimeOffset firstDate, string parameterName, DateTimeOffset secondDate, string secondDateName)
    => new InvalidIf(firstDate == secondDate, parameterName, $"must match with {secondDateName}");
  public static InvalidIf IsOld(DateTimeOffset date, string parameterName, DateTimeOffset now) 
    => new InvalidIf(_dateNotRecent(date, now), parameterName, "must be recent");
  private static bool _dateNotRecent(DateTimeOffset date, DateTimeOffset currentDateTime)
  {
    TimeSpan timeDifference = currentDateTime.Subtract(date);
    TimeSpan oneMinute = TimeSpan.FromMinutes(1);

    return timeDifference.Duration() > oneMinute;
  }
}
