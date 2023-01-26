using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIServices.RestServices;
namespace API.Tests
{
    public static class Services
    {
        public static IServiceCollection AddApi(this IServiceCollection services) => services
           .AddScoped<RestApiService>()
           .AddScoped<ReqResServices>();
    }
}
