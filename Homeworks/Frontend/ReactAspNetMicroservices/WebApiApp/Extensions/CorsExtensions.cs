namespace WebApiApp.Extensions;

public static class ApiCorsPolicies
{
    public const string AllowAllOrigins = nameof(AllowAllOrigins);
    public const string AllowSpecificOrigins = nameof(AllowSpecificOrigins);
    public const string AllowMultipleOrigins = nameof(AllowMultipleOrigins);
    public const string AllowSpecificRoute = nameof(AllowSpecificRoute);
}

public static class CorsExtensions
{
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(ApiCorsPolicies.AllowAllOrigins, policy =>
            {
                policy
                    .AllowAnyOrigin() // Разрешить запросы с любого домена
                    .AllowAnyMethod() // Разрешить любые HTTP-методы
                    .AllowAnyHeader(); // Разрешить любые заголовки
            });

            options.AddPolicy(ApiCorsPolicies.AllowSpecificOrigins, policy =>
            {
                policy.WithOrigins("http://localhost:5272")
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyHeader();
            });

            options.AddPolicy(ApiCorsPolicies.AllowMultipleOrigins, policy =>
            {
                policy.WithOrigins("https://example.com", "http://example.com", "http://localhost:5272") // Разрешить несколько доменов
                    .WithMethods("GET", "POST") // Разрешить только GET и POST
                    .AllowCredentials() // Разрешить использование credentials
                    .WithHeaders("Origin", "Content-Type", "Authorization"); // Разрешить только указанные заголовки
            });
        });

        return services;
    }
}
