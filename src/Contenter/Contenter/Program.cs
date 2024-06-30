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

    var minus_folder = Environment.GetEnvironmentVariable("minus_folder");
    builder.Services.AddDbContext<Contenter.Data.Database>(options => options.UseSqlite($"Data Source={minus_folder}\\dbs\\Contenter.db3", b => b.MigrationsAssembly("Contenter")));
    builder.Services.AddDbContext<Contenter.Data.ApplicationDbContext>(options => options.UseSqlite($"Data Source={minus_folder}\\dbs\\Contenter-auth.db3", b => b.MigrationsAssembly("Contenter")));

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddIdentityCore<Contenter.Data.ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
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
