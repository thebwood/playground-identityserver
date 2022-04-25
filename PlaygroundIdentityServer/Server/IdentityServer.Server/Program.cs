using IdentityServer.Server.Configuration;
var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
// Add services to the container.
var connectionString = builder.Configuration["Identity"];
builder.Services.AddIdentityServer()
    .AddInMemoryClients(IdentityServerConfiguration.Clients)
    .AddInMemoryApiScopes(IdentityServerConfiguration.ApiScopes)
    .AddDeveloperSigningCredential();


var app = builder.Build();
app.UseIdentityServer();

app.Run();
