using WebApplication1.DataAccess.Models;

namespace WebApplication1.DTO
{
    public class LoginDto
    {
        public string email { get; set;}

        public string Password { get; set;}
    }

    public class LoggedInUserDetails
    {
        public Student Student { get; set; }

        public string AccessToken { get; set; }
    }
}
