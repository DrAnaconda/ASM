using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme.Options;

namespace Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme
{
    // TODO: Move into shared repository
    public sealed class WhiteListAuthorizationScheme : 
        AuthenticationHandler<WhiteListAuthSchemeOptions>
    {
        private readonly WhiteListAuthSchemeOptions _config;

        public WhiteListAuthorizationScheme(
            IOptionsMonitor<WhiteListAuthSchemeOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _config = options.CurrentValue;
        }
        
        private static string extractToken(HttpRequest context)
        {
            if (!context.Headers.ContainsKey("Authorization")) return string.Empty;
            
            return context.Headers["Authorization"][0];
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = extractToken(Request);
            if ((token?.Any() == true && _config.keys.Contains(token)) 
                || !_config.isEnabled)
            {
                // TODO: Move scheme name to options
                var identity = new ClaimsIdentity(_config.authorizationSchemeName);
                var claims = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(claims, _config.authorizationSchemeName);
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            
            return Task.FromResult(AuthenticateResult.Fail(string.Empty));
        }
    }
}