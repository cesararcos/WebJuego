using WebJuegoUI.Utilities;
using WebJuegoUI.Utilities.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient(); // Registrar HttpClient para consumir la API

builder.Services.AddTransient<IJuegoService, JuegoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Juego}/{action=Index}/{id?}");

app.Run();
