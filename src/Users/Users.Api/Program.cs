using Bmg.Desafio.Core.Api.Middlewares;
using Bmg.Desafio.Users.Api;
using Bmg.Desafio.Users.Identity; // ApplicationUser
using System.Text.Json.Serialization; // added
using Microsoft.OpenApi.Models;
using Bmg.Desafio.Users.Identity.Security; // add jwt

namespace Users.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    // Remove $id/$ref metadata by avoiding ReferenceHandler.Preserve
                    // and ignore cycles instead of preserving references.
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users.Api", Version = "v1" });

                // JWT Bearer security to enable Authorize button
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                });
            });
            builder.Services.AddAuthorization();

            // Centraliza auth no IoC gerado (JWT + Cookie + DataProtection)
            builder.Services.InjectDependencies(builder.Configuration);
            // Additionally ensure JWT bearer is wired

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            // Added authentication middleware before authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.OnAppInitialized();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.Run();
        }
    }
}

