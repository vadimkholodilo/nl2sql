using Grpc.Core;
using Nl2Sql.Api.Services;
using static Nl2Sql.Api.Services.Translator;

namespace Nl2Sql.Api;

public class TranslatorService : TranslatorBase
{

    public override async Task<TranslateToSqlResponse> TranslateToSql(TranslateToSqlRequest request, ServerCallContext context)
    {
        throw new NotImplementedException();
    }

}
