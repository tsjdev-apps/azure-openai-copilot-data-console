using SimpleAzureOpenAIChat.Models;
using System.Text.Json;

namespace SimpleAzureOpenAIChat.ExtensionMethods;


public static class HttpResponseMessageExtensions
{
    public static async Task<ChatMessage?> GetAssistantChatMessageAsync(
        this HttpResponseMessage httpResponseMessage)
    {
        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new Exception();

        string content = await httpResponseMessage.Content
            .ReadAsStringAsync();

        RequestResponse? response = JsonSerializer
            .Deserialize<RequestResponse>(content);

        return response?
            .Choices?.FirstOrDefault()?
            .Messages?
            .FirstOrDefault(m => m.Role == "assistant");
    }
}
