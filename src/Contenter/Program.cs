using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;

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
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();
    builder.Services.AddFluentUIComponents();

    builder.Services.AddCascadingAuthenticationState();
    builder.Services.AddScoped<Contenter.Components.Account.IdentityUserAccessor>();
    builder.Services.AddScoped<Contenter.Components.Account.IdentityRedirectManager>();
    builder.Services.AddScoped<AuthenticationStateProvider, Contenter.Components.Account.IdentityRevalidatingAuthenticationStateProvider>();
    builder.Services.AddAuthentication(options => {
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

    var app = builder.Build();

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

    app.Run();
  }
}
