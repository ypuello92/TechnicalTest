using TechnicalTest.Infraestructure.DependencyInjection;
using TechnicalTest.Aplication.DependencyInjectionserv;
using TechnicalTest.Api.StartTest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfraestructureInjections(builder.Configuration);
builder.Services.AddSqlServerConnection(builder.Configuration);
builder.Services.AddServiceInjections(builder.Configuration);

builder.Services.AddHostedService<StartTest>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
