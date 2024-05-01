using Microsoft.OpenApi.Models;
using Bancario.Infrastructure;
using Bancario.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    }); ;
});

// Dependencias da Aplicação
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();