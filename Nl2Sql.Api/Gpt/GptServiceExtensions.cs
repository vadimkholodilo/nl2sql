using Microsoft.SemanticKernel;

namespace Nl2Sql.Api.Gpt;

public static class GptServiceExtensions
{
    public static IServiceCollection AddGptServices(this IServiceCollection services,
        IConfigurationManager configuration)
    {
        var openAiSettings = configuration.GetRequiredSection("OpenAiSettings").Get<OpenAiSettings>();
        services.AddScoped<IGptTranslator, GptTranslator>();
        services.AddOpenAIChatCompletion(openAiSettings.ModelId, openAiSettings.ApiKey);
        return services;
    }
}