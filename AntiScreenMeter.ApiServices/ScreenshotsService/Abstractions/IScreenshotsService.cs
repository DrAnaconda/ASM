using System.Threading.Tasks;

namespace AntiScreenMeter.ApiServices.ScreenshotsService.Abstractions
{
    public interface IScreenshotService
    {
        public Task<byte[]> GetRandomScreenshotAsync();
    }
}