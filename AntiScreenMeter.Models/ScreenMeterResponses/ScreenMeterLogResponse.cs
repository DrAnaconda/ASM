using System.Collections.Generic;

namespace AntiScreenMeter.Models.ScreenMeterResponses
{
    public class ScreenMeterLogResponse
    {
        public string sessionGuid { get; set; }

        public string signedUrl { get; set; }

        public string signedUrlthumb { get; set; }
    }
}