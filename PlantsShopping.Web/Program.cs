using Microsoft.AspNetCore.SpaServices.AngularCli;
using PlantsShopping.Web.Services;
using PlantsShopping.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Razor Pages (keeps any existing server pages), Controllers for API endpoints
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddHttpClient<IPlantService, PlantService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:PlantsShoppingApi"]));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
                "http://localhost:4200",
                "https://localhost:4200",
                "http://localhost:5200",
                "https://localhost:5201"
            )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

});

// Serve SPA static files when published (optional)
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Serve static files (wwwroot) so the built Angular production files copied into wwwroot are served
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

// Keep Razor Pages and API controllers active
app.MapRazorPages();
app.MapControllers();

// For SPA production: when no other endpoint matches, serve index.html so client-side routing works
app.MapFallbackToFile("index.html");

// When in development, start the Angular CLI server automatically when launching the web project from Visual Studio.
// This makes "Run" in Visual Studio start the Angular dev server and proxy client requests to it.
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
    if (app.Environment.IsDevelopment())
    {
        // This will run `npm start` inside ClientApp. Ensure ClientApp/package.json has a start script.
        spa.UseAngularCliServer(npmScript: "start");
    }
});

app.Run();
