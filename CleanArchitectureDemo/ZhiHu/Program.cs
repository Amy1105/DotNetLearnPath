
using Microsoft.AspNetCore.Builder;
using ZhiHu.Infrastructure;
using ZhiHu.UseCases;
using ZhiHu.Core;
using Microsoft.Extensions.DependencyInjection;
using ZhiHu;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using ZhiHu.Infrastructure.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddUseCaseServices();

builder.Services.AddCoreServices();

builder.Services.AddWebServices(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAny");

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(_ => { });

app.MapControllers();

app.Run();