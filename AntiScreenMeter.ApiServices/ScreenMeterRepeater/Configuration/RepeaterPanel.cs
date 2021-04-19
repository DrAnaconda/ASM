using System;

namespace AntiScreenMeter.ApiServices.ScreenMeterRepeater.Configuration
{
    public class RepeaterPanel
    {
        public bool isPaused { get; set; } = true;
        public DateTime? whenPause { get; set; } = null;
    }
}