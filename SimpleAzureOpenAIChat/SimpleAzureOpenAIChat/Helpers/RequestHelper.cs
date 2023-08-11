using Microsoft.Extensions.Configuration;
using SimpleAzureOpenAIChat.Models;
using System.Text;
using System.Text.Json;

namespace SimpleAzureOpenAIChat.Helpers;


public static class RequestHelper
{
    public static HttpRequestMessage CreateHttpRequestMessage(string endpoint, List<ChatMessage> messages, IConfigurationRoot configuration)
    {
        // get request body
        RequestBody requestBody = CreateRequestBody(messages, configuration);

        // serialize request body
        string requestContent = JsonSerializer.Serialize(requestBody);

        // create HttpRequestMessage
        HttpRequestMessage request = new(HttpMethod.Post, endpoint)
        {
            Content = new StringContent(requestContent, Encoding.UTF8, "application/json")
        };

        return request;
    }

    private static RequestBody CreateRequestBody(
        List<ChatMessage> messages,
        IConfigurationRoot configuration)
    {
        return new RequestBody(
            messages,
            new List<DataSource>
            {
                new DataSource(
                    new DataSourceParameters(
                        configuration["Azure:Search:Endpoint"],
                        configuration["Azure:Search:ApiKey"],
                        configuration["Azure:Search:IndexName"],
                        "You are the Copilot of Sebastian and " +
                        "you help with his Medium blog posts.",
                        new DataSourceParametersFieldsMapping()))
            });
    }
}
