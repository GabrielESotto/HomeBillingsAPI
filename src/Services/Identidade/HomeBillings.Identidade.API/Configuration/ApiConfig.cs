namespace HomeBillings.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "Origins",
                    policy =>
                    {
                        policy.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }

        public static WebApplicationBuilder UseApiConfiguration(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            app.UseCors("Origins");

            if (app.Environment.IsDevelopment())
            {
                builder.UseSwaggerConfiguration(app);
            }

            app.UseHttpsRedirection();

            builder.UseIdentityConfiguration(app);

            app.MapControllers();

            app.Run();

            return builder;
        }
    }
}
