using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup.Auth
{
    public class FakeAuthConfiguration
    {
        public FakeAuthConfiguration()
        {
            InjectFakeAuthenticatedUser = true;
        }

        public bool InjectFakeAuthenticatedUser { get; set; }
    }

    public static class AuthSetup
    {
        public static void AddFakeAuth(this IServiceCollection services)
        {
            services.AddSingleton<FakeAuthConfiguration>();

            services.AddAuthentication("Fake")
                .AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>("Fake", _ => { });
        }
    }
}
