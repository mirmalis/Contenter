using Aper.Api.Services._2Processing;
using Aper.Api.Services._3Orchestrations;

namespace Aper.Api.Services._4Aggregators;

public class TopChannelFunctions: ITopChannelFunctions
{
  #region Constructors
  IChannelsOrchestratorService channels { get; }
  ITopPlaylistFunctions playlists { get; }
  IVideoOrchestrationService videos { get; }

  public TopChannelFunctions(
    IChannelsOrchestratorService channels,
    ITopPlaylistFunctions playlists,
    IVideoOrchestrationService videos
  )
  {
    this.channels = channels;
    this.playlists = playlists;
    this.videos = videos;
  }
  #endregion

  public async ValueTask<IEnumerable<object>> GetChannelsLatestVideos(string channelId)
  {
    var channel = await this.channels.GetChannel(channelId:  channelId);
    if(channel is null)
      throw new Exception($"Channel (id={channelId}) doesn't exist");

    var result = await this.playlists.GetPlaylistsLatestVideos(channel.UploadsPlaylistId!);
    return result;
  }
}
