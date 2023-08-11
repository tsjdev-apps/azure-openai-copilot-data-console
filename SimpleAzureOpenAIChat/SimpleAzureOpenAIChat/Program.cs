using Microsoft.Extensions.Configuration;
using SimpleAzureOpenAIChat.ExtensionMethods;
using SimpleAzureOpenAIChat.Helpers;
using SimpleAzureOpenAIChat.Models;
using System.Net.Http.Json;
using System.Text.Json;

// 1. Make user secrets accessible
IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

// 2. Setup messages list
List<ChatMessage> messages = new();

// 3. Create httpClient with headers
HttpClient httpClient = HttpClientHelper.CreateHttpClient(configuration);

while (true)
{
    // 4. Get message from the user
    Console.WriteLine("USER MESSAGE:");
    string? messageContent = Console.ReadLine();
    messages.Add(new ChatMessage("user", messageContent));

    // 5. Create request
    string endpoint = $"https://{configuration["Azure:OpenAI:Resource"]}.openai.azure.com/" +
        $"openai/deployments/{configuration["Azure:OpenAI:Deployment"]}/" +
        $"extensions/chat/completions?api-version=2023-06-01-preview";
    HttpRequestMessage requestMessage = RequestHelper.CreateHttpRequestMessage(endpoint, messages, configuration);

    // 6. Make request
    HttpResponseMessage response = await httpClient
        .SendAsync(requestMessage);

    // 7. Handle request
    ChatMessage? assistantMessage = await response
        .GetAssistantChatMessageAsync();

    if (assistantMessage is not null)
    {
        messages.Add(assistantMessage);
        Console.WriteLine();
        Console.WriteLine($"COPILOT ANSWER: {assistantMessage.Content}");
        Console.WriteLine();
        Console.WriteLine();
    }
}