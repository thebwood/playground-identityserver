using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
// Add services to the container.
var connectionString = builder.Configuration["Identity"];
builder.Services.AddIdentityServer()
    .AddInMemoryClients(new List<Client>())
    .AddInMemoryIdentityResources(new List<IdentityResource>())
    .AddInMemoryApiResources(new List<ApiResource>())
    .AddInMemoryApiScopes(new List<ApiScope>())
    .AddTestUsers(new List<TestUser>())
    .AddDeveloperSigningCredential();


var app = builder.Build();
app.UseIdentityServer();

app.Run();
