using HomeBillings.Core.Identidade;
using HomeBillings.Identidade.API.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HomeBillings.Identidade.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddJwtConfiguration(builder.Configuration);
            services.AddAuthorization();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static WebApplicationBuilder UseIdentityConfiguration(this WebApplicationBuilder builder, WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return builder;
        }
    }
}
