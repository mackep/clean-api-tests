using CleanTestsApiExample.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTestsApiExample
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuth(_config);
            services.AddPrimaryAdapters();
            services.AddCoreServices();
            services.AddSecondaryAdapters(_config);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ConfigureApplication();
        }
    }
}
