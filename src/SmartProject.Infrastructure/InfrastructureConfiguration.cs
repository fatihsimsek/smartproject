using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using SmartProject.Domain;
using SmartProject.Domain.Features;
using SmartProject.Infrastructure.Features;

namespace SmartProject.Infrastructure
{
	public static class InfrastructureConfiguration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                    .AddCheck("self", () => HealthCheckResult.Healthy("Application is running"))
                    .AddSqlServer(configuration["Database:SqlConnectionString"]!);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddDbContext<ISmartDbContext, SmartDbContext>(builder => builder.UseSqlServer(configuration["ConnectionStrings:SmartProject"]));
            services.AddTransient<IRepository<Order>, OrderRepository>();

            return services;
        }

        public static IEndpointRouteBuilder UseInfrastructure(this IEndpointRouteBuilder app)
        {
            app.MapHealthChecks("healthz");
            app.MapHealthChecks("liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });

            return app;
        }
	}
}

