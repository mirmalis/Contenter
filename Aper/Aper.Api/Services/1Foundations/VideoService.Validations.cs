using Aper.Models.Videos;

namespace Aper.Api.Services._1Foundations;

public partial class VideoService
{
  protected override TException ValidateInput_Common<TException>(TException x, Video video)
  {
    return x
      .AddInvalid(
        InvalidIf.InvalidId(video.Id, nameof(Video.Id)),
        InvalidIf.InvalidId(video.ChannelId, nameof(Video.ChannelId)),
        InvalidIf.IsDefault(video.Title, nameof(Video.Title)),
        InvalidIf.IsDefault(video.PublishedAt, nameof(Video.PublishedAt))
      )
      .AddInvalid(
        InvalidIf.IsDefault(video.CreatedDate, nameof(Video.CreatedDate)),
        InvalidIf.IsDefault(video.UpdatedDate, nameof(Video.UpdatedDate)),
        InvalidIf.IsOld(video.UpdatedDate, nameof(Video.UpdatedDate), now)
      );
  }
  protected override TException ValidateInput_CreateSpecific<TException>(TException x, Video video)
  { 
    return x.AddInvalid(
      InvalidIf.IsDiferent(video.CreatedDate, nameof(Video.CreatedDate), video.UpdatedDate, nameof(Video.UpdatedDate))
    );
  }
  protected override TException ValidateInput_ModifySpecific<TException>(TException x, Video video)
  {
    return x.AddInvalid(
      InvalidIf.IsSame(video.CreatedDate, nameof(Video.CreatedDate), video.UpdatedDate, nameof(Video.UpdatedDate))
    );
  }

  protected override TException Validate_AgainstStorageObject<TException>(TException x, Video input, Video core)
  {
    return x.AddInvalid
    (
      InvalidIf.IdDiferent(input.Id, nameof(Video.Id), core.Id, nameof(Video.Id)) // Id can't change.
    );
  }
}
