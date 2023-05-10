using Microsoft.AspNetCore.Cors.Infrastructure;
using GitHubProxy.Application.Services.Interfaces;
using GitHubProxy.Application.Services;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GitHub Proxy API",
        Description = "Simple Web API that wrapper GitHub Rest Api",
        TermsOfService = new Uri("https://spiritsoftware.co.uk"),
        Contact = new OpenApiContact
        {
            Name = "Ian Maher",
            Url = new Uri("https://spiritsoftware.co.uk")
        }
    });
});

//Add application Services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGitHubService, GitHubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

