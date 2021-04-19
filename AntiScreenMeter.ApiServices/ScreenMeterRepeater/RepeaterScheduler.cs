using System;
using System.Threading;
using System.Threading.Tasks;
using AntiScreenMeter.ApiServices.ScreenMeterRepeater.Configuration;
using AntiScreenMeter.ApiServices.ScreenshotsService.Abstractions;
using AntiScreenMeter.ScreenMeterFaker.Abstractions;
using Microsoft.Extensions.Hosting;

namespace AntiScreenMeter.ApiServices.ScreenMeterRepeater
{
    public class RepeaterScheduler : IHostedService
    {
        private readonly IScreenMeter _screenMeter;
        private readonly IScreenshotService _screenshotService;
        
        private readonly RepeaterPanel _repeaterPanel;
        
        private Timer _timerScreener;
        private Timer _syncer;

        public RepeaterScheduler(
            IScreenMeter screenMeter,
            IScreenshotService screenshotService,
            RepeaterPanel repeaterPanel)
        {
            _screenMeter = screenMeter;
            _screenshotService = screenshotService;
            _repeaterPanel = repeaterPanel;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _screenMeter.AuthorizeAsync();
            
            this._repeaterPanel.sessionStartedAt = DateTime.UtcNow;

            _timerScreener = new Timer(
                SyncScreenshots, null, TimeSpan.Zero, 
                TimeSpan.FromMinutes(_screenMeter.GetScreenshotSyncPeriodInMinutes())
            );
            
            _syncer = new Timer(UsualSync, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timerScreener?.Change(Timeout.Infinite, 0);
            _syncer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private bool checkPause()
        {
            if (_repeaterPanel.isPaused) return true;
            if (_repeaterPanel.whenPause != null && DateTime.UtcNow > _repeaterPanel.whenPause.Value)
            {
                this._repeaterPanel.isPaused = true;
                return true;
            }

            return false;
        }

        private void UsualSync(object? state)
        {
            if (this.checkPause()) return;
            
            _screenMeter.SendReportAsync().GetAwaiter().GetResult();
            _repeaterPanel.lastSyncWas = DateTime.UtcNow;
        }
        
        private void SyncScreenshots(object? state)
        {
            if (this.checkPause()) return;
            
            var randomScreenshot = _screenshotService.GetRandomScreenshotAsync().GetAwaiter().GetResult();
            _screenMeter.SendScreenshotReportAsync(randomScreenshot).GetAwaiter().GetResult();
            _repeaterPanel.lastScreenshotWasSentAt = DateTime.UtcNow;
        }
    }
}