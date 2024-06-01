namespace Nl2Sql.Api.Gpt;

public interface IGptTranslator
{
 Task<string> TranslateFromNaturalLanguageToSql(string query, string databaseSchema, string databaseProvider);
}