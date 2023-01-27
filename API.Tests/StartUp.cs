using APIServices;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

[Binding]
public class StartUp 
{
    public static ServiceProvider ServiceProvider;
    public StartUp()
    {

    }

    [BeforeTestRun(Order = 0)]
    public static void OneTimeSetup()
    {
        ServiceProvider = TestDependencies.CreateServices().BuildServiceProvider();
        ServiceProvider.GetService<GlobalTestSettings>();
    }
}