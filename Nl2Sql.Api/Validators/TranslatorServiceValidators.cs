using System.Text;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Nl2Sql.Api.Models.Constants;
using Nl2Sql.Api.Services;

namespace Nl2Sql.Api.Validators;

public class TranslatorServiceValidators : Interceptor
{
    public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        // Since Translator service has only one method, there is no reason to check a method's name.
        var validationErrors = _validateTranslateToSqlRequest(request as TranslateToSqlRequest);
        if (!string.IsNullOrEmpty(validationErrors))
            throw new RpcException(new Status(StatusCode.InvalidArgument, validationErrors));

        return continuation(request, context);
    }

    private string _validateTranslateToSqlRequest(TranslateToSqlRequest request)
    {
        StringBuilder validationErrors = new();

        if (string.IsNullOrEmpty(request.Query)) validationErrors.AppendLine("Query can not be empty");

        if (string.IsNullOrEmpty(request.DatabaseSchema))
            validationErrors.AppendLine("Database schema can not be empty");

        if (!DatabaseProviders.SupportedDatabaseProviders.Contains(request.DatabaseProvider,
                StringComparer.InvariantCultureIgnoreCase))
            validationErrors.AppendLine(
                $"{request.DatabaseProvider} is not a valid database provider. The following database providers are supported {string.Join(", ", DatabaseProviders.SupportedDatabaseProviders)}");

        return validationErrors.ToString();
    }
}