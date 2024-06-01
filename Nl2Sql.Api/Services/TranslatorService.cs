using Grpc.Core;
using Nl2Sql.Api.Gpt;
using Nl2Sql.Api.Services;
using static Nl2Sql.Api.Services.Translator;

namespace Nl2Sql.Api;

public class TranslatorService : TranslatorBase
{
    private readonly ILogger<TranslatorService> _logger;
    private readonly IGptTranslator _gptTranslator;

    public TranslatorService(ILogger<TranslatorService> logger, IGptTranslator gptTranslator)
    {
        _logger = logger;
        _gptTranslator = gptTranslator;
    }

    public override async Task<TranslateToSqlResponse> TranslateToSql(TranslateToSqlRequest request,
        ServerCallContext context)
    {
        string sqlQuery = await _gptTranslator.TranslateFromNaturalLanguageToSql(request.Query,
            request.DatabaseSchema, request.DatabaseProvider);
        return new TranslateToSqlResponse()
        {
            Sql = sqlQuery
        };
    }
}