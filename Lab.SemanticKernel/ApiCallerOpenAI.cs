using Microsoft.SemanticKernel;
using ReadSecretsConsole;

namespace Lab.SemanticKernel
{
    internal class ApiCallerOpenAI : IApiCaller
    {
        private Microsoft.SemanticKernel.IKernel _kernel;

        public ApiCallerOpenAI()
        {
            _kernel = Kernel.Builder.Build();

            var secretAppsettingReader = new SecretAppsettingReader();
            var openAISecretValues = secretAppsettingReader.ReadSection("OpenAI", "ApiKey");

            _kernel.Config.AddOpenAITextCompletionService("davinci-openai",
                "text-davinci-003",               // OpenAI Model name
                openAISecretValues.Value       // OpenAI API Key
            );
        }

        public async Task Execute()
        {
            var prompt = @"{{$input}}One line TLDR with the fewest words.";

            var summarize = _kernel.CreateSemanticFunction(prompt);

            string text1 = @"
                1st Law of Thermodynamics - Energy cannot be created or destroyed.
                2nd Law of Thermodynamics - For a spontaneous process, the entropy of the universe increases.
                3rd Law of Thermodynamics - A perfect crystal at zero Kelvin has zero entropy.";

            string text2 = @"
                1. An object at rest remains at rest, and an object in motion remains in motion at constant speed and in a straight line unless acted on by an unbalanced force.
                2. The acceleration of an object depends on the mass of the object and the amount of force applied.
                3. Whenever one object exerts a force on another object, the second object exerts an equal and opposite on the first.";

            Console.WriteLine(await summarize.InvokeAsync(text1));

            Console.WriteLine(await summarize.InvokeAsync(text2));
        }
    }
}
