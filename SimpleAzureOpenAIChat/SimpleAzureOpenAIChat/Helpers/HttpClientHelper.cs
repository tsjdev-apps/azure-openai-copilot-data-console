using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace SimpleAzureOpenAIChat.Helpers;


public static class HttpClientHelper
{
    public static HttpClient CreateHttpClient(IConfigurationRoot configuration)
    {
        var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));        

        httpClient.DefaultRequestHeaders.Add(
            "api-key", 
            configuration["Azure:OpenAI:ApiKey"]);

        httpClient.DefaultRequestHeaders.Add(
            "x-ms-useragent", 
            "MyCopilotOnData/0.0.1");

        return httpClient;
    }
}
