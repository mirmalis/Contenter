using Aper.Models.Videos;

namespace Aper.Api.Services.Orchestrations;

public interface IVideoOrchestrationService
{
  ValueTask<Video?> GetVideo(string videoId);
}
