using System.IO;
using System.Threading.Tasks;
using AntiScreenMeter.ScreenMeterFaker.Abstractions;
using AntiScreenMeter.ScreenMeterFaker.Configuration;
using NUnit.Framework;

namespace AntiScreenMeter.Tests
{
    public class ScreenMeterTests
    {
        private IScreenMeter _screenMeter;
        private ScreenMeterConfiguration _screenMeterConfiguration;
        
        [SetUp]
        public void Setup()
        {
            this._screenMeterConfiguration = new ScreenMeterConfiguration()
            {
                username = "***REMOVED***", password = "***REMOVED***"
            };
            this._screenMeter = new ScreenMeterFaker.Implementation.ScreenMeterFaker(_screenMeterConfiguration);
        }

        [Test]
        public async Task AuthorizeRealUser_ShouldSuccess()
        {
            var response = await this._screenMeter.AuthorizeAsync();
            Assert.AreEqual("Ejaw Games", response.companyName);
        }

        [Test, Explicit]
        public async Task SendScreenShot_ShouldNotFail_SemiAutomatic()
        {
            const string pathToScreenshot = "";
            var filesBytes = await File.ReadAllBytesAsync(pathToScreenshot);
            await this._screenMeter.SendScreenshotReportAsync(filesBytes);
        }
    }
}