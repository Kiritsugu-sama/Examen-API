using Examen_AlvaroReyes.DB.Examen;
using Examen_AlvaroReyes.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ExamenEntities>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDb")));

// Servicios
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();


//swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Examen API", Version = "v1" });
});

var app = builder.Build();

// Configuración del pipeline
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examen API V1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();