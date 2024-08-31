using Contenter.Brokers.Youtube;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.AspNetCore.Authentication;
using Contenter.Brokers.Contents;
using Contenter.Brokers.Sources;

namespace Contenter;
public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);

    var cultureInfo = new System.Globalization.CultureInfo("lt-LT");
    System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();
    builder.Services.AddFluentUIComponents();
    builder.Services.AddHttpClient();
    builder.Services.AddScoped<IYoutubeBroker, YoutubeBroker>();
    builder.Services.AddScoped<IContentBroker, ContentBroker>();
    builder.Services.AddScoped<ISourceBroker, SourceBroker>();
    builder.Services.AddScoped<Data.IStorageBroker, Data.Database>();
    builder.Services.AddCascadingAuthenticationState();
    builder.Services.AddScoped<Contenter.Components.Account.IdentityUserAccessor>();
    builder.Services.AddScoped<Contenter.Components.Account.IdentityRedirectManager>();
    builder.Services.AddScoped<AuthenticationStateProvider, Contenter.Components.Account.IdentityRevalidatingAuthenticationStateProvider>();
    builder.Services
      .AddAuthentication(options => {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
      })
      .AddIdentityCookies();
    builder.Services.AddAuthorization(options => {
      options.AddPolicy("AdminSuper", policy => {
        policy.RequireClaim("admin", "super");
      });
    });

    var minus_folder = Environment.GetEnvironmentVariable("minus_folder");
    var dbConntectionString = builder.Configuration.GetConnectionString("Database");
    var authDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");
    builder.Services.AddDbContext<Contenter.Data.Database>(options => options.UseSqlite(dbConntectionString, b => b.MigrationsAssembly("Contenter")));
    builder.Services.AddDbContext<Contenter.Data.ApplicationDbContext>(options => options.UseSqlite(authDbConnectionString, b => b.MigrationsAssembly("Contenter")));

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddIdentityCore<Contenter.Data.ApplicationUser>(options => {
      options.SignIn.RequireConfirmedAccount = false;
    })
        .AddEntityFrameworkStores<Contenter.Data.ApplicationDbContext>()
        .AddSignInManager()
        .AddDefaultTokenProviders();

    builder.Services.AddSingleton<IEmailSender<Contenter.Data.ApplicationUser>, Contenter.Components.Account.IdentityNoOpEmailSender>();
    builder.Services.AddDataGridEntityFrameworkAdapter();
    builder.Services.AddCors(options => options.AddPolicy("AllowYoutube", 
      builder => builder.WithOrigins("https://www.youtube.com", "www.youtube.com", "youtube.com").AllowAnyMethod().AllowAnyHeader()));
    var app = builder.Build();
    app.UseCors("AllowYoutube");
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseMigrationsEndPoint();
    }
    else
    {
      app.UseExceptionHandler("/Error");
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<Contenter.Components.App>()
        .AddInteractiveServerRenderMode();

    // Add additional endpoints required by the Identity /Account Razor components.
    app.MapAdditionalIdentityEndpoints();
    app.MapControllers();
    
    app.Run();
  }
}
