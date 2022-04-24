using Microsoft.EntityFrameworkCore;
using People.API.Extensions;
using People.Core.Services;
using People.Core.Services.Interfaces;
using People.Infrastructure.Entities;
using People.Infrastructure.Repositories;
using People.Infrastructure.Repositories.Interfaces;

var siteCorsPolicy = "SiteCorsPolicy";

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
ServiceExtensions.ConfigureCors(builder.Services, siteCorsPolicy);



builder.Services.AddControllers();
ServiceExtensions.AddDependencyInjection(builder.Services, builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(siteCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
