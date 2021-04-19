using System.IO;

namespace AntiScreenMeter.ApiServices.ScreenshotsService.Configuration
{
    public class ScreenshotServiceConfiguration
    {
        public string pathToFolderWithFiles { get; set; } = Directory.GetCurrentDirectory();
    }
}