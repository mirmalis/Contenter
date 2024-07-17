using Contenter.Data;
using Contenter.Models.Sources;
using Contenter.Services.Views.Youtube;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contenter.Controllers;
[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class ContentController: ControllerBase
{
  private readonly Database db;
  private readonly IYoutubeBroker yt;

  #region Constructors
  public ContentController(Contenter.Data.Database db, IYoutubeBroker aper)
  {
    this.db = db;
    this.yt = aper;
  }
  #endregion
  [HttpPost]
  public async Task<ActionResult<Guid?>> Post(string identifier)
  {
    var obj = await this.yt.GetVideoInfo(identifier);
    if(obj == null) {
      return NotFound(null);
    }
    // todo: būtų galima prieš aper krepinį padaryt. Tik v kaip ištraukt iš identifier (reiktų aper logiką dubliuot).
    var sources = await this.db.Set<Contenter.Models.Sources.Source>()
      .Where(item => item.Href == obj.Href)
      .Include(item => item.ContentAssignments)
      .ToListAsync()
    ;
    if(sources != null)
    {
      var ids = sources.SelectMany(s => s.ContentAssignments);
      if (ids.Any())
      {
        return Ok(ids.First().ContentId);
        // TODO: dadaryt
      }
    }
    var content = new Contenter.Models.Contents.Content() {
      PublishedAt = obj.PublishedAt,
      Name = obj.Title,
      SourceAssignments = [
        new Contenter.Models.Contents.ContentSources(){
          Source = new Source() {
            Href = obj.Href,
            PlatformId = "yt",
            DefinitionUid = "video",
          },
          Index = 1,
        }
      ]
    };
    
    this.db.Add(content);
    await this.db.SaveChangesAsync();


    return Ok(content.Id);
  }
  [HttpGet]
  public ActionResult<string> Test()
  {
    return "api works";
  }
}
