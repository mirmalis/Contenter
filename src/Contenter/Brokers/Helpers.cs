namespace Contenter.Brokers;

public class Helpers
{
  public static T ChangeFlag<T>(T start, bool state, T flag)
    where T: System.Enum
  {
    dynamic dStart = start;
    dynamic dFlag = flag;
    if (state)
    {
      if (start.HasFlag(flag))
        return start;
      dStart ^= dFlag;
    }
    else
    {
      if (!start.HasFlag(flag))
        return start;
      dStart &= ~dFlag;
    }
    return (T)dStart;
  }
}
