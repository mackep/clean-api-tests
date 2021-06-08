using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup
{
    public class ProgramWithFakes : WebApplicationFactory<StartupWithFakes>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StartupWithFakes>();
                });
        }
    }
}