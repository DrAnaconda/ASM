using System;

namespace AntiScreenMeter.ApiServices.ScreenMeterRepeater.Configuration
{
    public class RepeaterPanel
    {
        public bool isPaused { get; set; } = true;
        public DateTime? whenPause { get; set; } = null;
        
        public DateTime? lastScreenshotWasSentAt { get; set; }
        public DateTime? lastSyncWas { get; set; }
        public DateTime? sessionStartedAt { get; set; }
    }
}