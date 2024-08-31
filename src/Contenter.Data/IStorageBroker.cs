namespace Contenter.Data;
public interface IStorageBroker
{
  Task CreateOrUpdateMany(IEnumerable<Models.Sources.Source> sources);
  Task MarkChannelAsFullScrapedAt(Guid channelId, DateTimeOffset at);
}