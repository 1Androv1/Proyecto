using Contexts;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);
var glpsConnectionString = builder.Configuration.GetConnectionString("CONNECTION_STRING");

// Add services to the container.
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar DbContext para Entity Framework Core
builder.Services.AddDbContext<SqlDbContext>(options =>
    options.UseSqlServer(glpsConnectionString, b => b.MigrationsAssembly("BackEndProject")));

// Registrar servicios y repositorios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskService, TaksService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IAlimentosService, AlimentosService>();
builder.Services.AddScoped<IAlimentosRepository, AlimentosRepository>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "Cors",
        policy =>
        {
            policy.WithOrigins(
                    "http://localhost:5235",
                    "http://localhost:5500",
                    "http://localhost:5173"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Aplicar middleware de CORS antes del enrutamiento
    app.UseCors("Cors");
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();