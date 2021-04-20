using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme.Options
{
    public class WhiteListAuthSchemeOptions : AuthenticationSchemeOptions
    {
        public List<string> keys { get; set; }
    }
}