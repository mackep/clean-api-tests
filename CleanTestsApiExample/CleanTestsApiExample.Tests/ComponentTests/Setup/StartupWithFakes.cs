using CleanTestsApiExample.Setup;
using CleanTestsApiExample.Tests.ComponentTests.Setup.Auth;
using CleanTestsApiExample.Tests.ComponentTests.Setup.Dependencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup
{
    public class StartupWithFakes
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFakeAuth();
            services.AddControllers();
            services.AddCoreServices();
            services.AddFakeSecondaryAdapters();
            services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureApplication();
        }
    }
}