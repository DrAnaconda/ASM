using System.Threading.Tasks;
using AntiScreenMeter.Models.ScreenMeterRequests;
using AntiScreenMeter.Models.ScreenMeterResponses;

namespace AntiScreenMeter.ScreenMeterFaker.Abstractions
{
    public interface IScreenMeter
    {
        public Task<ScreenMeterLoginResponse> AuthorizeAsync();
        public Task<ScreenMeterLoginResponse> AuthorizeAsync(string userId, string password);
        public int GetScreenshotSyncPeriodInMinutes();
        public Task SendScreenshotReportAsync(byte[] screenshotBytes);
        public Task SendReportAsync();
    }
}