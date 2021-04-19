using System.Threading.Tasks;
using AntiScreenMeter.ApiServices.ScreenshotsService.Abstractions;
using AntiScreenMeter.ApiServices.ScreenshotsService.Configuration;

namespace AntiScreenMeter.ApiServices.ScreenshotsService.Implementations
{
    public class ScreenshotsService : IScreenshotService
    {
        private readonly ScreenshotServiceConfiguration _configuration;

        public ScreenshotsService(ScreenshotServiceConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public Task<byte[]> GetRandomScreenshotAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}