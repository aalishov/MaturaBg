
using MaturaBg.Data;
using MaturaBg.Data.Models;
using MaturaBg.Features.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MaturaBg.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ApplicationSetting GetApplicationSettings(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            var ApplicationSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSetting>(ApplicationSettingsConfig);
            return ApplicationSettingsConfig.Get<ApplicationSetting>();



        }
        public static IServiceCollection AddDatabase(
             this IServiceCollection services,
             IConfiguration configuration
            )
        => services
            .AddDbContext<AppDbContext>( options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                    .AddDefaultIdentity<User>(
                        options =>
                        {
                            options.Password.RequiredLength = 6;
                            options.Password.RequireDigit = false;
                            options.Password.RequireLowercase = false;
                            options.Password.RequireNonAlphanumeric = false;
                            options.Password.RequireUppercase = false;
                        })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            ApplicationSetting appSettings)
        {
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(
               x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })


              .AddJwtBearer(
               x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });



            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)

            => services
                .AddTransient<IIdentityService, IdentityService>();

    }
}
