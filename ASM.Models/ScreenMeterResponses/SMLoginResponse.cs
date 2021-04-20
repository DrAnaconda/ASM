using System;
using System.Collections.Generic;
using ASM.Models.ScreenMeterModels;

namespace ASM.Models.ScreenMeterResponses
{
    public class SMLoginResponse
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object email { get; set; }
        public int screenshotInterval { get; set; }
        public int reminderInterval { get; set; }
        public bool disableScreenCapture { get; set; }
        public bool denySelfAssignedTasks { get; set; }
        public bool disableInactivityReminder { get; set; }
        public string userName { get; set; }
        public string guid { get; set; }
        public int version { get; set; }
        public string companyName { get; set; }
        public List<ProjectDataSet> ProjectDataSet { get; set; }
        public ActiveProject activeProject { get; set; }
        public DateTime ServerTimeUTC { get; set; }
    }
}