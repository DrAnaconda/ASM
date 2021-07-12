using System;

namespace ASM.Models.ScreenMeterRequests
{
    public class SMManualLogCreateRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string __RequestVerificationToken { get; set; }
        public string EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectTaskId { get; set; }

        public SMManualLogCreateRequest(
            DateTime StartTime,
            DateTime EndTime,
            string crfxToken,
            string employeeId,
            int projectId,
            int projectTaskId)
        {
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            __RequestVerificationToken = crfxToken;
            this.EmployeeId = employeeId;
            this.ProjectId = projectId;
            this.ProjectTaskId = projectTaskId;
        }
    }
}