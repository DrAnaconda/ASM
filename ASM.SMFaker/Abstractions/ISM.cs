using System.Threading.Tasks;
using ASM.Models.ScreenMeterResponses;

namespace ASM.ScreenMeterFaker.Abstractions
{
    public interface ISM
    {
        public Task<SMLoginResponse> AuthorizeAsync();
        
        public Task<SMLoginResponse> AuthorizeAsync(string userId, string password);
        public int GetScreenshotSyncPeriodInMinutes();
        public Task SendScreenshotReportAsync(byte[] screenshotBytes);
        public Task SendReportAsync();
    }
}