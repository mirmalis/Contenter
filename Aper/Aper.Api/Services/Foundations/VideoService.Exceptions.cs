using Aper.Models;
using Aper.Models.Videos;

namespace Aper.Api.Services.Foundations;

public partial class VideoService
{
  protected override Xeptions.Xeption newInvalidInputException() => new X_InvalidException<Video>();
  protected override Xeptions.Xeption newNullInputException() => new X_NullException<Video>();
  
  protected override Exception UpcastException(Exception ex)
  {
    return ex switch
    {
      (NullException nullException) => new X_ValidationException<Video>(nullException),
      _ => base.UpcastException(ex)
    };
  }
}
