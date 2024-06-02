using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace Nl2Sql.Api.Gpt;

public class GptTranslator : IGptTranslator
{

    private readonly IChatCompletionService _chat;

    public GptTranslator(IChatCompletionService chat)
    {
        _chat = chat;
    }

    public async Task<string> TranslateFromNaturalLanguageToSql(string query, string databaseSchema,
        string databaseProvider)
    {
        string prompt = PromptsLibrary.TranslateNaturalLanguageToSql(query, databaseSchema, databaseProvider);
        ChatMessageContent result = await _chat.GetChatMessageContentAsync(prompt);
        return result.Content;
    }
}