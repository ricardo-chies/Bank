using Microsoft.OpenApi.Models;
using Bancario.Infrastructure;
using Bancario.Application;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner.
// Aprenda mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Description = "Este microsservi�o tem como objetivo disponibilizar endpoints relacionados a acesso, an�lise e movimenta��o banc�ria.",
        Contact = new OpenApiContact
        {
            Name = "Ricardo Chies",
            Email = "chies.dev@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/ricardo-chies-087557216/")
        },
        Title = "Bancario",
        Version = "v1"
    });
});

// Adiciona a configura��o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Depend�ncias da Aplica��o
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configura o pipeline de requisi��o
app.UseSwagger();
app.UseSwaggerUI();

// Adiciona o middleware CORS
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
