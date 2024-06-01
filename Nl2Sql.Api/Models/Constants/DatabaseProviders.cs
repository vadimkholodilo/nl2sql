namespace Nl2Sql.Api.Models.Constants;

public static class DatabaseProviders
{
    public static readonly IReadOnlyList<string> SupportedDatabaseProviders =
        CollectionExtensions.AsReadOnly(new List<string> { "sqlite", "postgresql", "mysql", "sql server" });
}