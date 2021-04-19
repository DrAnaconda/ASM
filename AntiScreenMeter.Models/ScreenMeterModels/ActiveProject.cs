using System.Collections.Generic;

namespace AntiScreenMeter.Models.ScreenMeterResponses
{
    public class ActiveProject
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public List<object> completedTasks { get; set; }
        public List<OpenTask> openTasks { get; set; }
    }
}