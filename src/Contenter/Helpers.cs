namespace Contenter;

static class Helpers
{
  public static System.Linq.Expressions.Expression<Func<string, string>> NameRetrievalExpression(int maxLength)
  {
    return (name) => name.Length > maxLength ? name.Substring(0, maxLength) + ".." : name;
  }
}
