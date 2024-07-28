using Aper.Api.Brokers.Storages;
using Aper.Api.Brokers.TruthBrokers;
using Aper.Api.Services.Foundations.Channels;
using Aper.Api.Services.Foundations.PlaylistItems;
using Aper.Api.Services.Foundations.Playlists;
using Aper.Api.Services.Foundations.Videos;

using Google.Apis.Services;

namespace Aper.Api;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddSingleton<BaseClientService.Initializer>();

    builder.Services.AddTransient<ITrueDataBroker, YoutubeApiBroker>();
    builder.Services.AddDbContext<IStorageBroker, StorageBroker>();
    builder.Services.AddTransient<IChannelService, ChannelService>();
    builder.Services.AddTransient<IVideoService, VideoService>();
    builder.Services.AddTransient<IPlaylistService, PlaylistService>();
    builder.Services.AddTransient<IPlaylistItemService, PlaylistItemService>();

    builder.Services.AddControllers();
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
