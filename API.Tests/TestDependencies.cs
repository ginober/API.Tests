using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;

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
                    //cfg.AddInMemoryCollection(TestContext.Parameters);
                    
                });

        hostbuilder.Build();
        ConfigureServices(services, hostBuilderContext);

        return services;
    }

    private static void ConfigureServices(ServiceCollection services, HostBuilderContext hostBuilderContext)
    {
        services
            .AddSingleton(hostBuilderContext.Configuration);
    }
}