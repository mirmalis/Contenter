﻿using Aper.Api.Services.Foundations;
using Aper.Api.Services.Orchestrations;
using Aper.Models;
using Aper.Models.Videos;

using Microsoft.AspNetCore.Mvc;

using RESTFulSense.Controllers;

namespace Aper.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class YoutubeVideoController: RESTFulController
{
  #region Constructors
  public YoutubeVideoController(IVideoOrchestrationService videoService) : base()
  {
    this.videoOrchestrator = videoService;
  }
  private IVideoOrchestrationService videoOrchestrator { get; }
  #endregion
  //[HttpPost]
  //public async Task<ActionResult> PostVideoAsync(Video video)
  //{
  //  try
  //  {
  //    var created = await this.videoOrchestrator(video);
  //    return Created(created);
  //  }
  //  catch (Exception ex)
  //  {
  //    return BadRequest(ex);
  //  }
  //}
  [HttpGet]
  public async Task<ActionResult<Video?>> GetVideoAsync(string videoId)
  {
    try
    {
      var existing = await this.videoOrchestrator.GetVideo(videoId);
      return existing;
    } catch (Exception ex)
    {
      return BadRequest(ex);
    }
  }
}
