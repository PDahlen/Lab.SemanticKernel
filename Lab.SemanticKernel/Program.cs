
using Lab.SemanticKernel;

Console.WriteLine($"Azure OpenAI");
var azureOpenAICaller = new ApiCallerAzureOpenAI();
await azureOpenAICaller.Execute();

Console.WriteLine($"OpenAI");
var openAICaller = new ApiCallerOpenAI();
await openAICaller.Execute();

Console.ReadKey();
