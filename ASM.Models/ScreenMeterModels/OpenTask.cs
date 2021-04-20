namespace ASM.Models.ScreenMeterResponses
{
    public class OpenTask
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public bool canMarkComplete { get; set; }
        public bool canArchive { get; set; }
    }
}