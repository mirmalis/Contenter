
namespace Aper.Api.Services._4Aggregators;

public interface IVideoAggregator
{
  ValueTask<object?> GetVideo(string videoId);
}
