using Contenter.Models.Sources;

namespace Contenter.Brokers.Sources;

public interface ISourceBroker
{
  IQueryable<Source> Q { get; }

  Task<List<T>> GetListByCreationDate<T>(System.Linq.Expressions.Expression<Func<Contenter.Models.Sources.Source, T>> expression, int max = 100, int skip = 0);
  Task<T?> GetOneById<T>(System.Linq.Expressions.Expression<Func<Contenter.Models.Sources.Source, T>> expression, Guid id);
  Task<bool> Mark_as_WontHaveContent_ById(Guid sourceId);
  Task<bool> Shown_at_MainPage(Guid sourceId, bool state);
}
