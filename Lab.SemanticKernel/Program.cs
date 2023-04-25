using ReadSecretsConsole;

var secretAppsettingReader = new SecretAppsettingReader();
var openAISecretValues = secretAppsettingReader.ReadSection("OpenAI", "ApiKey");
var azureOpenAISecretValues = secretAppsettingReader.ReadSection("AzureOpenAI", "ApiKey");

Console.WriteLine($"The value for {openAISecretValues.Path} is: {openAISecretValues.Value}");
Console.WriteLine($"The value for {openAISecretValues.Path} is: {azureOpenAISecretValues.Value}");

Console.ReadKey();
