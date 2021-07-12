namespace ASM.Models.ScreenMeterModels
{
    public class CompletedTask
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public bool canMarkComplete { get; set; }
        public bool canArchive { get; set; }
    }
}