using Aper.Api.Brokers.DateTimes;
using Aper.Api.Brokers.Logging;
using Aper.Api.Brokers.Storages;
using Aper.Api.Brokers.TruthBrokers;
using Aper.Api.Services.Foundations;
using Aper.Api.Services.Orchestrations;
using Aper.Api.Services.Processing;
using Aper.Models.Videos;

using Google.Apis.Services;

namespace Aper.Api;

public class Program
{

  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddSingleton<BaseClientService.Initializer>();
    builder.Services.AddSingleton<IDateTimeBroker, DateTimeBroker>();
    builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
    builder.Services.AddTransient<ITrueDataBroker, YoutubeApiBroker>();
    builder.Services.AddDbContext<IStorageBroker, StorageBroker>();
    builder.Services.AddTransient<IChannelService, ChannelService>();
    builder.Services.AddTransient<IChannelProcessingService, ChannelProcessingService>();
    builder.Services.AddTransient<IVideoService, VideoService>();
    builder.Services.AddTransient<IVideoProcessingService, VideoProcessingService>();
    builder.Services.AddTransient<IVideoOrchestrationService, VideoOrchestrationService>();

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
