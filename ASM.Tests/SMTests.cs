using System.IO;
using System.Threading.Tasks;
using ASM.ScreenMeterFaker.Abstractions;
using ASM.ScreenMeterFaker.Configuration;
using NUnit.Framework;

namespace ASM.Tests
{
    public class SMTests
    {
        private ISM _ism;
        private SMConfiguration _smConfiguration;
        
        [SetUp]
        public void Setup()
        {
            this._smConfiguration = new SMConfiguration()
            {
                username = "***REMOVED***", password = "***REMOVED***"
            };
            this._ism = new ScreenMeterFaker.Implementation.IsmFaker(_smConfiguration);
        }

        [Test, Explicit]
        public async Task AuthorizeRealUser_ShouldSuccess()
        {
            var response = await this._ism.AuthorizeAsync();
            // TODO: Make more `safely` assert 
        }

        [Test, Explicit]
        public async Task SendScreenShot_ShouldNotFail_SemiAutomatic()
        {
            const string pathToTestScreenshot = @"C:\Projects\AntiSM\AntiScreenMeter\ASM.WebApi\wwwroot\images\Time_2021_04_05_14_02_29.png";
            var filesBytes = await File.ReadAllBytesAsync(pathToTestScreenshot);
            await this._ism.AuthorizeAsync();
            await this._ism.SendScreenshotReportAsync(filesBytes);
        }

        [Test, Explicit]
        public async Task SendEvent_ShouldNotFail_SemiAutomatic()
        {
            await this._ism.AuthorizeAsync();
            await this._ism.SendReportAsync();
        }
    }
}