using M365HealthCheckApp.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.TokenCacheProviders.InMemory;
using Microsoft.Identity.Web.UI; 

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
  .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

  
builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddInMemoryTokenCaches();

  
builder.Services.AddTokenAcquisition();

// MVC Controllers  
builder.Services.AddControllersWithViews();

// App Services  
builder.Services.AddScoped<GraphService>();
builder.Services.AddScoped<PowerShellService>();

var app = builder.Build();

// Middleware pipeline  
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Directory}/{action=Index}/{id?}");

app.Run();
