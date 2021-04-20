namespace ASM.Models.ScreenMeterRequests
{
    public class SMLoginRequest
    {
        public string UserName { get; set; }
        public int ActiveProjectId { get; set; } = -1;
        public string Password { get; set; }
        public string LoginAuxData { get; set; } = "SMElectronv0";

        public SMLoginRequest(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }
    }
}