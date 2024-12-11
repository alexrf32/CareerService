using CareerService.Src.Data;
using CareerService.Src.Repositories;
using CareerService.Src.Services;
using CareerService.Protos;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuración de MongoDB
builder.Services.Configure<CareerServiceDbSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton(sp =>
{
    var settings = sp.GetRequiredService<IOptions<CareerServiceDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

// Registrar repositorios
builder.Services.AddSingleton<CareerRepository>();
builder.Services.AddSingleton<SubjectRepository>();
builder.Services.AddSingleton<SubjectRelationshipRepository>();

// Agregar servicios gRPC
builder.Services.AddGrpc();

// Agregar reflexión gRPC
builder.Services.AddGrpcReflection();

// Configurar autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "CareerServiceAPI",
            ValidAudience = "CareerServiceClient",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSuperSecretKey"))
        };
    });

// Agregar autorización
builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware para manejar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapear servicios gRPC
app.MapGrpcService<CareerService.Src.Services.CareerService>();
app.MapGrpcService<CareerService.Src.Services.SubjectService>();
app.MapGrpcService<CareerService.Src.Services.SubjectRelationshipServiceImpl>();

// Mapear el servicio de reflexión gRPC (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

// Endpoint de salud opcional
app.MapGet("/", () => "CareerService API is running.");

app.Run();
