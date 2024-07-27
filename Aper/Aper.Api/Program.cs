using Aper.Api.Brokers.Storages;
using Aper.Api.Brokers.YoutubeApiBrokers;
using Aper.Api.Services;

using Google.Apis.Services;

using Microsoft.EntityFrameworkCore;
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
    builder.Services.AddTransient<IVideoService, VideoService>();

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
