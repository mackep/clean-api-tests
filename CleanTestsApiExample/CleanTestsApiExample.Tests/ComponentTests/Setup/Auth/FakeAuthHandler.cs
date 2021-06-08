using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CleanTestsApiExample.Tests.ComponentTests.Setup.Auth
{
    public class FakeAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly FakeAuthConfiguration _config;

        public FakeAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            FakeAuthConfiguration config) : base(options, logger, encoder, clock)
        {
            _config = config;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            await Task.CompletedTask;

            if (!_config.InjectFakeAuthenticatedUser)
                return AuthenticateResult.Fail("Skipping injection of fake authenticated user");

            var claims = new[] { new Claim(ClaimTypes.Name, "Test user") };
            var identity = new ClaimsIdentity(claims, "Test");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Fake authentication scheme");

            var result = AuthenticateResult.Success(ticket);

            return result;
        }
    }
}