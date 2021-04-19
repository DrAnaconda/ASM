namespace AntiScreenMeter.Models.ScreenMeterRequests
{
    public class ScreenMeterLoginRequest
    {
        public string UserName { get; set; }
        public int ActiveProjectId { get; set; } = -1;
        public string Password { get; set; }
        public string LoginAuxData { get; set; } = "SMElectronv0";

        public ScreenMeterLoginRequest(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}