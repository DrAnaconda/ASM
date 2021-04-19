namespace AntiScreenMeter.ScreenMeterFaker.Configuration
{
    public class ScreenMeterConfiguration
    {
        public string username { get; set; }
        public string password { get; set; }
        public string baseUrl { get; set; } = "https://www.screenmeter.com/api";
        public int mouseClicksPerMinute { get; set; } = 30;
        public int keyboardClicksPerMinute { get; set; } = 80;
    }
}