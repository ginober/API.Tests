using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}