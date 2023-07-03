using System.Text.Json.Serialization;

namespace SimpleAzureOpenAIChat.Models;

public record RequestResponse(
    [property: JsonPropertyName("id")] string? Id,
    [property: JsonPropertyName("model")] string? Model,
    [property: JsonPropertyName("created")] int Created,
    [property: JsonPropertyName("choices")] ResponseChoice[]? Choices);

public record ResponseChoice(
    [property: JsonPropertyName("messages")] ChatMessage[]? Messages);
