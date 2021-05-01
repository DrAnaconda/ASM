using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme.Options
{
    public class WhiteListAuthSchemeOptions : AuthenticationSchemeOptions
    {
        public string authorizationSchemeName { get; set; } = nameof(WhiteListAuthorizationScheme);
        public bool isEnabled { get; set; } = true;
        public List<string> keys { get; set; }
    }
}