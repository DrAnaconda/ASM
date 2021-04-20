using System;

namespace ASM.Models.ScreenMeterModels
{
    public class LogData
    {
        public string auxData { get; set; } = "chrome_mac_new";
        public bool forceWorkingStatus { get; set; } = false;
        public string guid { get; set; } = Guid.NewGuid().ToString();
        public bool inactivityAlert { get; set; } = false;
        public bool isScreenshot { get; set; }
        public bool isStartLog { get; set; }
        public int keyCount { get; set; } = 0;
        public int mouseCount { get; set; } = 0;
        public int taskId { get; set; }
        public string windowTitle { get; set; } = "Not Implemented";

        public LogData(int taskId, int mouseCount, int keyCount, bool isStartLog, bool isScreenshot)
        {
            this.taskId = taskId;
            this.mouseCount = mouseCount;
            this.keyCount = keyCount;
            this.isStartLog = isStartLog;
            this.isScreenshot = isScreenshot;
        }

        public void regenerateLogData(/*int mouseCountIncrease, int keyBoardEventsIncrease,*/ bool isScreenshotReport)
        {
            this.guid = Guid.NewGuid().ToString();
            this.isStartLog = false;
            //this.keyCount += keyBoardEventsIncrease;
            //this.mouseCount += mouseCountIncrease;
            this.isScreenshot = isScreenshotReport;
        }
    }
}