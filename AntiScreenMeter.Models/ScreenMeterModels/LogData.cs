namespace AntiScreenMeter.Models.ScreenMeterResponses
{
    public class LogData
    {
        public string auxData { get; set; }
        public bool forceWorkingStatus { get; set; }
        public string guid { get; set; }
        public bool inactivityAlert { get; set; }
        public bool isScreenshot { get; set; }
        public bool isStartLog { get; set; }
        public int keyCount { get; set; }
        public int mouseCount { get; set; }
        public int taskId { get; set; }
        public string windowTitle { get; set; }
    }
}