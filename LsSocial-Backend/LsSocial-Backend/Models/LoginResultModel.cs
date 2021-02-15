namespace LsSocial_Backend.Models
{
    public class LoginResultModel
    {
        public string Token { get; set; }

        public UserModel UserModel { get; set; }
    }
}