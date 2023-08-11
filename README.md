# Use Azure OpenAI to create a Copilot on your own data

![Logo](./docs/image.png)

Microsoft enables the options to add your own data to Azure OpenAI to create your personal Copilot, which works on your data. 

This repository contains a simple console application written in .NET 7 to demonstrate how to call an Azure OpenAI service with custom data.

## Usage
 
The application uses the [Microsoft.Extensions.Configuration.UserSecrets NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.UserSecrets), so the credentials are not part of the source code.

You need an Azure OpenAI service and a pre-configured Azure Cognitive Search service with a search index. Than you just need to set the following credentials using a Terminal with Visual Studio.

```bash
dotnet user-secrets set Azure:Search:Endpoint <COMPLETE ENDPOINT>
dotnet user-secrets set Azure:Search:ApiKey <API KEY>
dotnet user-secrets set Azure:Search:IndexName <INDEX NAME>

dotnet user-secrets set Azure:OpenAI:Resource = <JUST RESOURCE NAME>
dotnet user-secrets set Azure:OpenAI:Deployment = <DEPLOYMENT NAME>
dotnet user-secrets set Azure:OpenAI:ApiKey = <API KEY>
```

## Blog Posts

If you are more interested into details, please see the following [medium.com](https://www.medium.com) posts:

- [Use Azure OpenAI to create a Copilot on your own data — Part 1](https://medium.com/medialesson/use-azure-openai-to-create-a-copilot-on-your-own-data-part-1-ba1d997298ca)

- [Use Azure OpenAI to create a Copilot on your own data in C#— Part 2](https://medium.com/medialesson/use-azure-openai-to-create-a-copilot-on-your-own-data-in-c-part-2-b7acc1922337)