using System.Text.Json.Serialization;

namespace SimpleAzureOpenAIChat.Models;


public record RequestBody(
    [property: JsonPropertyName("messages")] List<ChatMessage>? Messages,
    [property: JsonPropertyName("dataSources")] List<DataSource>? DataSources,
    [property: JsonPropertyName("temperature")] float Temperature = 0f,
    [property: JsonPropertyName("max_tokens")] int MaxTokens = 800,
    [property: JsonPropertyName("top_p")] float TopP = 1.0f,
    [property: JsonPropertyName("stop")] string? Stop = null,
    [property: JsonPropertyName("stream")] bool Stream = false);

public record DataSource(
    [property: JsonPropertyName("parameters")] DataSourceParameters? Parameters,
    [property: JsonPropertyName("type")] string? Type = "AzureCognitiveSearch");

public record DataSourceParameters(
    [property: JsonPropertyName("endpoint")] string? SearchEndpoint,
    [property: JsonPropertyName("key")] string? SearchApiKey,
    [property: JsonPropertyName("indexName")] string? SearchIndexName,
    [property: JsonPropertyName("roleInformation")] string? RoleInformation,
    [property: JsonPropertyName("fieldsMapping")] DataSourceParametersFieldsMapping? FieldsMapping,
    [property: JsonPropertyName("inScope")] bool InScope = true,
    [property: JsonPropertyName("topNDocuments")] string? TopNDocuments = "5",
    [property: JsonPropertyName("queryType")] string? QueryType = "simple",
    [property: JsonPropertyName("semanticConfiguration")] string? SemanticConfiguration = "");

public record DataSourceParametersFieldsMapping(
    [property: JsonPropertyName("contentFields")] string[]? ContentFields = default,
    [property: JsonPropertyName("titleField")] string? TitleField = null,
    [property: JsonPropertyName("urlField")] string? UrlField = null,
    [property: JsonPropertyName("filepathField")] string? FilePathField = null);

