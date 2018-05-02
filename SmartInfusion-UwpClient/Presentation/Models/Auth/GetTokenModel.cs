namespace SmartInfusion_UwpClient.Presentation.Models.Auth
{
    public class GetTokenModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
