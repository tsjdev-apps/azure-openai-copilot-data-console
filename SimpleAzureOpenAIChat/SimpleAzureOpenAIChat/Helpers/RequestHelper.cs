using Microsoft.Extensions.Configuration;
using SimpleAzureOpenAIChat.Models;

namespace SimpleAzureOpenAIChat.Helpers;


public static class RequestHelper
{
    public static RequestBody CreateRequestBody(
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
