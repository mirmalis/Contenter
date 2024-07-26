using Aper.Api.Brokers;

using Microsoft.EntityFrameworkCore;
namespace Aper.Api;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var aperDbConntextString = builder.Configuration.GetConnectionString("Aper");
    builder.Services.AddTransient<IYoutubeApiBroker, YoutubeApiBroker>();
    builder.Services.AddDbContext<Database>(options => options.UseSqlite(aperDbConntextString, b => b.MigrationsAssembly("Aper.Api")));
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
