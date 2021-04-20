using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.WebEncoders.Testing;
using Moq;
using NUnit.Framework;
using Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme;
using Tools.Library.Authorization.Schemes.WhiteListAuthorizationScheme.Options;

namespace Tools.Library.Authorization.Tests
{
    [Parallelizable(ParallelScope.Self)]
    public class WhiteListAuthorizationSchemeTests
    {
        #region Test configuration
        private const string validToken = "validToken";
        private const string invalidToken = "invalidToken";
        #endregion

        private WhiteListAuthorizationScheme _authorizationScheme;
        private IOptionsMonitor<WhiteListAuthSchemeOptions> _optionsMonitor;
        
        // TODO: Inject http context
        [SetUp]
        public void Setup()
        {
            _optionsMonitor = mockOptionsMonitor();
            _authorizationScheme = new WhiteListAuthorizationScheme(_optionsMonitor, 
                new NullLoggerFactory(), new UrlTestEncoder(), new SystemClock());
        }

        [Test]
        public async Task Authorize_ValidToken_ShouldReturnSuccess()
        {
            var result = await _authorizationScheme.AuthenticateAsync();
            Assert.IsTrue(result.Succeeded);
            Assert.IsNotNull(result.Ticket);
        }

        [Test]
        public async Task Authorize_InvalidToken_ShouldReject()
        {
            var result = await _authorizationScheme.AuthenticateAsync();
            Assert.IsFalse(result.Succeeded);
            Assert.IsNull(result.Ticket);
        }

        private static IOptionsMonitor<WhiteListAuthSchemeOptions> mockOptionsMonitor()
        {
            var mocker = new Mock<IOptionsMonitor<WhiteListAuthSchemeOptions>>(MockBehavior.Loose);
            var currentAuthOptions = generateAuthOptions();

            mocker.SetupGet(x => x.CurrentValue).Returns(currentAuthOptions);

            return mocker.Object;
        }

        private static WhiteListAuthSchemeOptions generateAuthOptions()
        {
            return new()
            {
                keys = new List<string>() {validToken}
            };
        }
    }
}