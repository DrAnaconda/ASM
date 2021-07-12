using System;
using System.IO;
using System.Threading.Tasks;
using ASM.Models.ScreenMeterRequests;
using ASM.ScreenMeterFaker.Abstractions;
using ASM.ScreenMeterFaker.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace ASM.Tests
{
    public class SMTests
    {
        private ISM _ism;
        private IOptions<SMConfiguration> _smConfiguration;
        
        [SetUp]
        public void Setup()
        {
            this._smConfiguration = generateConfiguration();
            this._ism = new ScreenMeterFaker.Implementation.IsmFaker(_smConfiguration);
        }

        [Test]
        public async Task RetrieveTimeSheets_ShouldNotFail()
        {
            var request = generateTimesheetRequest();
            var authResponse = await _ism.AuthorizeAsync();
            var userData = await _ism.RetrieveUserData();
            var result = await _ism.RetrieveTimeSheetAsync(request);
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

        private SMTimesheetRequest generateTimesheetRequest()
        {
            var dt = DateTime.Now;
            return new(dt.Day, dt.Month, dt.Year);
        }
        

        private IOptions<SMConfiguration> generateConfiguration()
        {
            var mocker = new Mock<IOptions<SMConfiguration>>();
            var config = new SMConfiguration()
            {
                username = "YourScreenMeterUser", password = "YourScreenMeterPassword"
            };

            mocker.Setup(x => x.Value).Returns(config);
            
            return mocker.Object;
        }
    }
}
