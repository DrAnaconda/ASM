using System;

namespace ASM.Models.ScreenMeterModels
{
    public class WeeklyReport : ReportBase
    {
        public DateTime weekStart { get; set; }
        public DateTime weekEnd => weekStart.AddDays(7);
    }
}