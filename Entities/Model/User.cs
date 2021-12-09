namespace Entities.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int SecurityLevel { get; set; }
    }
}