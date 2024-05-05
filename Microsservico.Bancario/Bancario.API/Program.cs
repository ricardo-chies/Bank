using Microsoft.OpenApi.Models;
using Bancario.Infrastructure;
using Bancario.Application;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
// Aprenda mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Description = "Este microsserviço tem como objetivo disponibilizar endpoints relacionados a acesso, análise e movimentação bancária.",
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

// Adiciona a configuração CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Dependências da Aplicação
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configura o pipeline de requisição
app.UseSwagger();
app.UseSwaggerUI();

// Adiciona o middleware CORS
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
