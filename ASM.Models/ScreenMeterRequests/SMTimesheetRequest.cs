namespace ASM.Models.ScreenMeterRequests
{
    public class SMTimesheetRequest
    {
        public int year { get; set; }
        /// <summary>
        /// Should be with leading zero
        /// </summary>
        public string month { get; set; }
        /// <summary>
        /// Should be with leading zero
        /// </summary>
        public string day { get; set; }

        public int diff { get; set; } = -1;

        public SMTimesheetRequest(int day, int month, int year)
        {
            this.day = (day < 10) ? $"0{day}" : day.ToString();
            this.month = (month < 10) ? $"0{month}" : month.ToString();
            this.year = year;
        }

        public SMTimesheetRequest(int diff, int day, int month, int year) : this(day, month, year)
        {
            this.diff = diff;
        }
    }
}