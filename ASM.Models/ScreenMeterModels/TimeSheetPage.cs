namespace ASM.Models.ScreenMeterModels
{
    public class TimeSheetPage
    {
        public DailyReport[] DailyReport { get; set; }
        public WeeklyReport[] WeeklyReport { get; set; }
        public ManualLog[] ManualLogs { get; set; }
    }
}