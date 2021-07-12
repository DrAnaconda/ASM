using System.Collections.Generic;

namespace ASM.Models.ScreenMeterModels
{
    public class ActiveProject
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public List<object> completedTasks { get; set; }
        public List<OpenTask> openTasks { get; set; }
    }
}