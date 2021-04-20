using System;
using System.Threading;
using System.Threading.Tasks;
using ASM.ApiServices.FilesService.Abstractions;
using ASM.ApiServices.SMRepeater.Configuration;
using ASM.ScreenMeterFaker.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ASM.ApiServices.SMRepeater
{
    public class RepeaterScheduler : IHostedService
    {
        private readonly ISM _ism;
        private readonly IFilesService _filesService;
        
        private readonly RepeaterConfiguration _repeaterConfiguration;
        
        private Timer _timerScreener;
        private Timer _syncer;

        public RepeaterScheduler(
            ISM ism,
            IFilesService filesService,
            IOptions<RepeaterConfiguration> repeaterConfiguration)
        {
            _ism = ism;
            _filesService = filesService;
            _repeaterConfiguration = repeaterConfiguration.Value;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _ism.AuthorizeAsync();
            
            this._repeaterConfiguration.sessionStartedAt = DateTime.UtcNow;

            _timerScreener = new Timer(
                SyncScreenshots, null, TimeSpan.Zero, 
                TimeSpan.FromMinutes(_ism.GetScreenshotSyncPeriodInMinutes())
            );
            
            _syncer = new Timer(UsualSync, null, TimeSpan.Zero, TimeSpan.FromSeconds(50));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timerScreener?.Change(Timeout.Infinite, 0);
            _syncer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private bool checkPause()
        {
            if (_repeaterConfiguration.isPaused) return true;
            if (_repeaterConfiguration.whenPause != null && DateTime.UtcNow > _repeaterConfiguration.whenPause.Value)
            {
                this._repeaterConfiguration.isPaused = true;
                return true;
            }

            return false;
        }

        private void UsualSync(object? state)
        {
            if (this.checkPause()) return;
            
            _ism.SendReportAsync().GetAwaiter().GetResult();
            _repeaterConfiguration.lastSyncWas = DateTime.UtcNow;
        }
        
        private void SyncScreenshots(object? state)
        {
            if (this.checkPause()) return;
            
            var randomScreenshot = _filesService.GetRandomFileAsync().GetAwaiter().GetResult();
            _ism.SendScreenshotReportAsync(randomScreenshot).GetAwaiter().GetResult();
            _repeaterConfiguration.lastScreenshotWasSentAt = DateTime.UtcNow;
        }
    }
}