using Microsoft.IdentityModel.Tokens;
using People.API.Extensions;

var siteCorsPolicy = "SiteCorsPolicy";

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
ServiceExtensions.ConfigureCors(builder.Services, siteCorsPolicy);



builder.Services.AddControllers();
ServiceExtensions.AddPersistance(builder.Services, builder.Configuration);

ServiceExtensions.AddAuthenticationsAndAuthorizations(builder.Services);


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
