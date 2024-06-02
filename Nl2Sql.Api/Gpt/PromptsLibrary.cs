namespace Nl2Sql.Api.Gpt;

public static class PromptsLibrary
{

    public static string TranslateNaturalLanguageToSql(string query, string databaseSchema, string databaseProvider)
    {
        return $@"
You are a translator from natural language to SQL.
Use database schema provided below when constructing an sql query:
{databaseSchema}.

Query in natural language is provided below:
{query}.

Your SQL must be valid in {databaseProvider}.
You must produce only SQL as your response. No explanation needed.
";
    }
    
    
}