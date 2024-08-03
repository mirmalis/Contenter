namespace Aper.Api.Models.Videos;

public class VideoValidationException(Exception innerException): 
  Xeptions.Xeption(
    message: "Invalid input, contact support", 
    innerException)
{ }
