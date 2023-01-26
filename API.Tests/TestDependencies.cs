using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using API.Tests.Utilities;
using API.Tests;

public static class TestDependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        HostBuilderContext hostBuilderContext = null;
        var hostbuilder = Host.CreateDefaultBuilder();
        hostbuilder.
                ConfigureAppConfiguration((ctx, cfg) =>
                {
                    hostBuilderContext = ctx;

                    var env = TestContext.Parameters["environment"];
                        cfg.AddInMemoryCollection(TestContext.Parameters.ToKeyValuePairs())
                            .AddJsonFile("GlobalSettings\\globalsettings.json",false)
                            .AddJsonFile($"GlobalSettings\\globalsettings.{env}.json",true)
                            .AddJsonFile($"appsettings.json",false);
                            
                });

        hostbuilder.Build();
        ConfigureServices(services, hostBuilderContext);

        return services;
    }

    private static void ConfigureServices(ServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        services
            .AddSingleton(hostBuilderContext.Configuration)
            .AddApi();
    }
}