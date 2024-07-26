//namespace Aper.Api;
//using Aper.Api.Youtube;
//class Selectors
//{
//  public static System.Linq.Expressions.Expression<Func<Aper.Models.Video, Api.Youtube.Video>> Video_YoutubeVideo { get; set; } =
//    (data) => new Api.Youtube.Video() {
//      Id = data.Id,
//      Author = new ChannelIdentifier() {
//        Id = data.AuthorId,
//        Title = data.Author.Title,
//      },
//      Title = data.Name,
//      PublishedAt = data.PublishedAt,
//    };
//}
