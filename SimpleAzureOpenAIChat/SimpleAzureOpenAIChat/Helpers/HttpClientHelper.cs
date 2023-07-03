﻿using Microsoft.Extensions.Configuration;

namespace SimpleAzureOpenAIChat.Helpers;


public static class HttpClientHelper
{
    public static HttpClient CreateHttpClient(IConfigurationRoot configuration)
    {
        var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Add(
            "api-key", 
            configuration["Azure:OpenAI:ApiKey"]);

        httpClient.DefaultRequestHeaders.Add(
            "chatgpt_url", 
            $"https://{configuration["Azure:OpenAI:Resource"]}.openai.azure.com/openai/" +
            $"deployments/{configuration["Azure:OpenAI:Deployment"]}/" +
            $"completions?api-version=2023-03-15-preview");

        httpClient.DefaultRequestHeaders.Add(
            "chatgpt_key", 
            configuration["Azure:OpenAI:ApiKey"]);

        httpClient.DefaultRequestHeaders.Add(
            "x-ms-useragent", 
            "MyCopilotOnData/0.0.1");

        return httpClient;
    }
}