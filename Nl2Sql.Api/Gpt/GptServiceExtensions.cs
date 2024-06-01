namespace Nl2Sql.Api.Gpt;

public static class GptServiceExtensions
{
    public static IServiceCollection AddGptServices(this IServiceCollection services)
    {
        services.AddScoped<IGptTranslator, GptTranslator>();
        return services;
    }
}