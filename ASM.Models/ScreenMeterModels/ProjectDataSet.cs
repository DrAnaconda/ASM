using System.Collections.Generic;
using ASM.Models.ScreenMeterResponses;

namespace ASM.Models.ScreenMeterModels
{
    public class ProjectDataSet
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public List<CompletedTask> completedTasks { get; set; }
        public List<OpenTask> openTasks { get; set; }
    }
}