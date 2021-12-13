using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MaximaTech.DotnetChallenge.Web.Mocks
{
    public class MockAuthenticatedUser : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        const string userId = "admin";
        const string userName = "Administrador";
        const string userRole = "ProductManager";

        public MockAuthenticatedUser(
          IOptionsMonitor<AuthenticationSchemeOptions> options,
          ILoggerFactory logger,
          UrlEncoder encoder,
          ISystemClock clock)
          : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, userRole),
                new Claim(ClaimTypes.Email, "admin@email.com"),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return LoginState.Authenticated
                ? await Task.FromResult(AuthenticateResult.Success(ticket))
                : await Task.FromResult(AuthenticateResult.Fail("Faça login para acessar a aplicação."));
        }
    }
}