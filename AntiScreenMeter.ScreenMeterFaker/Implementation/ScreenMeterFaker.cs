using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntiScreenMeter.Models.ScreenMeterModels;
using AntiScreenMeter.Models.ScreenMeterRequests;
using AntiScreenMeter.Models.ScreenMeterResponses;
using AntiScreenMeter.ScreenMeterFaker.Abstractions;
using AntiScreenMeter.ScreenMeterFaker.Configuration;
using Tools.Library.HttpClient.Abstractions;
using Tools.Library.HttpClient.Implementations;

namespace AntiScreenMeter.ScreenMeterFaker.Implementation
{
    public class ScreenMeterFaker : IScreenMeter
    {
        private ScreenMeterLoginResponse screenMeterServerSettings { get; set; } = null;
        private LogData previousLogData { get; set; } = null;

        private readonly ScreenMeterConfiguration screenMeterConfiguration = new ScreenMeterConfiguration();

        private readonly ICustomHttpWrapper _customHttpWrapper;
        private readonly Random randomizer;

        #region Constructors

        public ScreenMeterFaker()
        {
            this._customHttpWrapper = new RestClientWrapper(this.screenMeterConfiguration.baseUrl);
        }

        public ScreenMeterFaker(ScreenMeterConfiguration configuration) : this()
        {
            this.screenMeterConfiguration = configuration;
        }

        #endregion

        public async Task<ScreenMeterLoginResponse> AuthorizeAsync()
        {
            if (this.screenMeterServerSettings == null)
            {
                var screenMeterAuthorizeBody = new ScreenMeterLoginRequest(
                    this.screenMeterConfiguration.username,
                    this.screenMeterConfiguration.password);

                this.screenMeterServerSettings = await _customHttpWrapper.MakeJsonPostRequestAsync
                    <ScreenMeterLoginResponse, ScreenMeterLoginRequest>(screenMeterAuthorizeBody, "login");
            }

            return this.screenMeterServerSettings;
        }

        public Task<ScreenMeterLoginResponse> AuthorizeAsync(string userId, string password)
        {
            this.screenMeterConfiguration.username = userId;
            this.screenMeterConfiguration.password = password;
            return AuthorizeAsync();
        }

        public int GetScreenshotSyncPeriodInMinutes()
        {
            return this.screenMeterServerSettings.screenshotInterval;
        }

        public async Task SendScreenshotReportAsync(byte[] screenshotBytes)
        {
            var request = buildLogRequest(true);
            ScreenMeterLogResponse linksForUpload = await this.retrieveLinksForUploading(request);
            var fullDefinitionTask = _customHttpWrapper.MakeJsonPutRequestAsync(screenshotBytes, linksForUpload.signedUrl);
            var thumbnailTask = _customHttpWrapper.MakeJsonPutRequestAsync(screenshotBytes, linksForUpload.signedUrlthumb);
            await Task.WhenAll(fullDefinitionTask, thumbnailTask);
        }

        public Task SendReportAsync()
        {
            var request = buildLogRequest(false);
            throw new NotImplementedException();
        }

        #region Logger builder
        
        private ScreenMeterLogRequest buildLogRequest(bool isScreenshot)
        {
            lock (this)
            {
                var logData = buildLogData(isScreenshot);
                var request = new ScreenMeterLogRequest(
                    logData,
                    this.screenMeterConfiguration.username,
                    this.screenMeterConfiguration.password);
                return request;
            }
        }

        private LogData buildLogData(bool isScreenshot)
        {
            if (this.previousLogData == null)
            {
                var currentTask = this.screenMeterServerSettings.activeProject.openTasks.First();
                this.previousLogData = new LogData(currentTask.taskId, 0, 0, true, true);
            }
            else
            {
                
                this.previousLogData.regenerateLogData(
                    randomizer.Next(this.screenMeterConfiguration.mouseClicksPerMinute),
                    randomizer.Next(this.screenMeterConfiguration.keyboardClicksPerMinute),
                    isScreenshot);
            }

            return this.previousLogData;
        }

        private Task<ScreenMeterLogResponse> retrieveLinksForUploading(ScreenMeterLogRequest request)
        {
            return _customHttpWrapper.MakeJsonPostRequestAsync
                <ScreenMeterLogResponse, ScreenMeterLogRequest>(request, "syncData");
        }

        #endregion
    }
}