using System;

namespace ASM.Models.ScreenMeterModels
{
    public class ManualLog
    {
        public string createdBy { get; set; }
        public string taskName { get; set; }
        public DateTime logStart { get; set; }
        public DateTime logEnd { get; set; }

        public double hoursSpent => (logEnd - logStart).TotalHours;
        public string status { get; set; }
    }
}