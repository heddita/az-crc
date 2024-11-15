using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(services =>
            {
                // Register CosmosClient as a singleton
                services.AddSingleton<CosmosClient>(sp =>
                {
                    var connectionString = Environment.GetEnvironmentVariable("AzureResumeConnectionString");
                    return new CosmosClient(connectionString);
                });
            })
            .Build();

        host.Run();
    }
}
