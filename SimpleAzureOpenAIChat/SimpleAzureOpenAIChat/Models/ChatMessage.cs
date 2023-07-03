using System.Text.Json.Serialization;

namespace SimpleAzureOpenAIChat.Models;


public record ChatMessage(
    [property: JsonPropertyName("role")] string? Role, 
    [property: JsonPropertyName("content")] string? Content);
