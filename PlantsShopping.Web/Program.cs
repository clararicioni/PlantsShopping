using PlantsShopping.Web.Services;
using PlantsShopping.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var plantsApiUrl = builder.Configuration["ServiceUrls:PlantsShoppingApi"];
if (string.IsNullOrEmpty(plantsApiUrl))
{
    throw new InvalidOperationException("Configuration key 'ServiceUrls:PlantsShoppingApi' is missing or empty. Set it in appsettings.json or environment variables.");
}
if (!Uri.TryCreate(plantsApiUrl, UriKind.Absolute, out var plantsApiUri))
{
    throw new InvalidOperationException($"Configuration key 'ServiceUrls:PlantsShoppingApi' is not a valid absolute URL: '{plantsApiUrl}'.");
}
builder.Services.AddHttpClient<IPlantService, PlantService>(c =>
    c.BaseAddress = plantsApiUri);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();