using Microsoft.EntityFrameworkCore;
using WebJuego.Application;
using WebJuego.Application.Contract;
using WebJuego.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:5011")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión BBDD
builder.Services.AddDbContext<JuegoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("database")));

// Inyección Dependencia
builder.Services.AddTransient<IJuegoAppService, JuegoAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
