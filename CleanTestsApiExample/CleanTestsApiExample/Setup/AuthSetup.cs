using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTestsApiExample.Setup
{
    public static class AuthSetup
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration config)
        {
            /*
             * In a real-world scenario, the authentication setup would be dependent
             * on some kind of configuration. In this example application, we omit
             * such details to keep things short and simple.
             */
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();
        }
    }
}
