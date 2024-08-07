using Aper.Api.Services._0Brokers.TruthBrokers;
using Aper.Api.Services._0Brokers.TruthBrokers.Models;

namespace Aper.Api.Services._1Foundations;

public interface IExternalVideoService { }
public class ExternalVideoService: IExternalVideoService
{
  #region Constructors
  public ITrueDataBroker api { get; }
  public ExternalVideoService(ITrueDataBroker trueDataBroker) : base()
  {
    this.api = trueDataBroker;
  }
  #endregion
  public async ValueTask<VideoDetails?> GetVideoDetails(string videoId)
  {
    if(videoId == null)
      throw new Exception($"{nameof(videoId)} is required.");
    if(videoId.Length != 11)
      throw new Exception($"{nameof(videoId)} has to be 11 characters long.");

    return await this.api.VideoDetails(videoId);
  }
}
