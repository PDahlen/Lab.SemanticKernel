using Microsoft.Extensions.Configuration;

namespace ReadSecretsConsole;

public class SecretAppsettingReader
{
    public IConfigurationSection ReadSection(string sectionName, string key)
    {
        var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        var section = configurationRoot.GetSection(sectionName).GetSection(key);

        return section;
    }
}