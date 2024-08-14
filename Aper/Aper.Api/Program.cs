using Aper.Api.Services._0Brokers.DateTimes;
using Aper.Api.Services._0Brokers.Logging;
using Aper.Api.Services._0Brokers.Storages;
using Aper.Api.Services._0Brokers.TruthBrokers;
using Aper.Api.Services._1Foundations;
using Aper.Api.Services._2Processing;
using Aper.Api.Services._3Orchestrations;
using Aper.Api.Services._4Aggregators;

using Google.Apis.Services;

namespace Aper.Api;

public class Program
{

  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSingleton<BaseClientService.Initializer>();
    // 0
    builder.Services.AddSingleton<IDateTimeBroker, DateTimeBroker>();
    builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
    builder.Services.AddTransient<ITrueDataBroker, YoutubeApiBroker>();
    builder.Services.AddDbContext<IStorageBroker, StorageBroker>();
    //1
    builder.Services.AddTransient<IChannelService, ChannelService>();
    builder.Services.AddTransient<IVideoService, VideoService>();
    builder.Services.AddTransient<IPlaylistService, PlaylistService>();
    builder.Services.AddTransient<IPlaylistItemsService, PlaylistItemsService>();
    //2
    builder.Services.AddTransient<IChannelProcessingService, ChannelProcessingService>();
    builder.Services.AddTransient<IPlaylistProcessingService, PlaylistProcessingService>();
    builder.Services.AddTransient<IVideoProcessingService, VideoProcessingService>();
    builder.Services.AddTransient<IPlaylistItemsProcessingService, PlaylistItemsProcessingService>();
    // 3
    builder.Services.AddTransient<IVideoOrchestrationService, VideoOrchestrationService>();
    builder.Services.AddTransient<IPlaylistOrchestrationService, PlaylistOrchestrationService>();
    builder.Services.AddTransient<IChannelsOrchestratorService, ChannelsOrchestratorService>();
    // 4
    builder.Services.AddTransient<ITopPlaylistFunctions, TopPlaylistFunctions>();
    builder.Services.AddTransient<ITopChannelFunctions, TopChannelFunctions>();
    builder.Services.AddTransient<IChannelAggregator, ChannelAggregator>();
    builder.Services.AddTransient<IVideoAggregator, VideoAggregator>();
    // 9
    builder.Services.AddControllers();

    builder.Services.AddMvc().AddJsonOptions(options => {
      options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();


    app.MapControllers();

    app.Run();
  }
}
