namespace ASM.Models.ScreenMeterModels
{
    public abstract class ReportBase
    {
        public string projectName { get; set; }
        public string projectTask { get; set; }
        public int secondsSpent { get; set; }
    }
}