using System;
using AntiScreenMeter.Models.ScreenMeterResponses;

namespace AntiScreenMeter.Models.ScreenMeterRequests
{
    public class ScreenMeterLogResult
    {
        public LogData logData { get; set; }
        public DateTime logTime { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string imageDataURLKey { get; set; }
        public string thumbDataURLKey { get; set; }
    }
}