using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using People.Core.Services;
using People.Core.Services.Interfaces;
using People.Infrastructure.Entities;
using People.Infrastructure.Repositories;
using People.Infrastructure.Repositories.Interfaces;

namespace People.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
                options.AddPolicy(policyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                    }
                )
            ); ;
        }

        public static void AddAuthenticationsAndAuthorizations(IServiceCollection services)
        {
            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "https://localhost:5443";
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };
                    });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "movieClient", "movies_mvc_client"));
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddTransient<IPeopleService, PeopleService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var connectionString = configuration["People"];
            services.AddDbContext<PeopleContext>(options => options.UseSqlServer(connectionString));

        }
    }
}
