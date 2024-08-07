using Aper.Exceptions;

namespace Aper.Api.Services._1Foundations;

internal static class Validators
{
  public static TException AddInvalid<TException>(this TException @this, params InvalidIf[] validations)
    where TException: Xeptions.Xeption
  {
    foreach (InvalidIf rule in validations)
    {
      if (rule.Condition)
      {
        @this.UpsertDataList(key: rule.ParameterName, value: rule.Message);
      }
    }
    return @this;
  }

  public static void Validate<T>(params InvalidIf[] validations)
  {
    var invalidObjectException = new InvalidObjectException<T>();

    foreach (InvalidIf rule in validations)
    {
      if (rule.Condition)
      {
        invalidObjectException.UpsertDataList(key: rule.ParameterName, value: rule.Message);
      }
    }
    invalidObjectException.ThrowIfContainsErrors();
  }

  //public static void ValidateAuditFields_OnCreate<T>(T obj, DateTimeOffset now)
  //  where T : class, IAuditable
  //{
  //  switch (obj)
  //  {
  //    case { } when obj.UpdatedBy != obj.CreatedBy:
  //      throw new InvalidObjectException<T>(
  //        parameterName: nameof(IAuditable.UpdatedBy),
  //        parameterValue: obj.UpdatedBy
  //      );
  //    case { } when obj.UpdatedDate != obj.CreatedDate:
  //      throw new InvalidObjectException<T>(
  //        parameterName: nameof(IAuditable.UpdatedDate),
  //        parameterValue: obj.UpdatedDate
  //      );
  //    case { } when IsDateNotRecent(obj.CreatedDate, now):
  //      throw new InvalidObjectException<T>(
  //        parameterName: nameof(IAuditable.CreatedDate),
  //        parameterValue: obj.CreatedDate
  //      );
  //  }
  //}
  //public static void ValidateAuditFields<T>(T obj)
  //  where T : class, IAuditable
  //{
  //  switch (obj)
  //  {
  //    case { } when IsInvalidId(obj.CreatedBy):
  //      throw new InvalidObjectException<T>(
  //        parameterName: nameof(IAuditable.CreatedBy),
  //        parameterValue: obj.CreatedBy
  //      );
  //    case { } when IsInvalidDate(obj.CreatedDate):
  //      throw new InvalidObjectException<T>(
  //        parameterName: nameof(IAuditable.CreatedDate),
  //        parameterValue: obj.CreatedDate
  //      );
  //    case { } when IsInvalidId(obj.UpdatedBy):
  //      throw new InvalidObjectException<T>(
  //        parameterName: nameof(IAuditable.UpdatedBy),
  //        parameterValue: obj.UpdatedBy
  //      );
  //    case { } when IsInvalidDate(obj.UpdatedDate):
  //      throw new InvalidObjectException<T>(
  //        parameterName: nameof(IAuditable.UpdatedDate),
  //        parameterValue: obj.UpdatedDate
  //      );
  //  }
  //}
  //public static void ValidateAuditAgainstStorage_OnModify<T>(T input, T stored)
  //  where T: IAuditable
  //{
  //  if (input == null)
  //    throw new ArgumentNullException(nameof(input));
  //  if(stored == null)
  //    throw new ArgumentNullException(nameof(stored));

  //  if (input.CreatedDate != stored.CreatedDate)
  //  {
  //    throw new InvalidObjectException<T>(nameof(IAuditable.CreatedDate), input.CreatedDate);
  //  }

  //  if (input.CreatedBy != stored.CreatedBy)
  //  {
  //    throw new InvalidObjectException<T>(nameof(IAuditable.CreatedBy), input.CreatedBy);
  //  }

  //  if (input.UpdatedDate == stored.UpdatedDate)
  //  {
  //    throw new InvalidObjectException<T>(nameof(IAuditable.UpdatedDate), input.UpdatedDate);
  //  }
  //}
}
