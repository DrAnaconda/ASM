using System;
using ASM.Models.ScreenMeterModels;
using ASM.Models.ScreenMeterResponses;

namespace ASM.Models.ScreenMeterRequests
{
    public class SMLogRequest
    {
        public LogData logData { get; }
        public DateTime logTime { get; set; } = DateTime.UtcNow;
        public string userName { get; }
        public string password { get; }
        public string imageDataURLKey { get; }
        public string thumbDataURLKey { get; }

        public SMLogRequest(LogData logData, string userName, string password)
        {
            this.logData = logData;
            this.userName = userName;
            this.password = password;
            this.imageDataURLKey = $"img_{Guid.NewGuid().ToString()}";
            this.thumbDataURLKey = $"img_{Guid.NewGuid().ToString()}";
        }
    }
}