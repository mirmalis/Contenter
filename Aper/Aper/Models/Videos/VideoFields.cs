namespace Aper.Models.Videos;

public enum VideoFields
{
  IsOther = 1 << 30,
  IsString = 1 << 29,
  IsNumber = 1 << 28,
  IsDateTime = 1 << 27,

  // IsNumber
  // IsString
  Title = 1 ^ IsString,
  Description = 2 ^ IsString,
  // IsOther
  Duration = 1 ^ IsOther
}
