using Aper.Api.Services._4Aggregators;

using Microsoft.AspNetCore.Mvc;

using RESTFulSense.Controllers;

namespace Aper.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ChannelController(IChannelAggregator service): RESTFulController
{
  public IChannelAggregator service { get; } = service;
  [HttpGet]
  public async Task<ActionResult<object>> GetChannel(string channelId)
  {
    var existing = await this.service.GetChannel(channelId);
    if (existing == null) {
      return NotFound(null);
    }
    return Ok(existing);
  }
}
