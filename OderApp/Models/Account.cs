namespace OderApp.Models
{
    public class Account
    {
        public Account(string email, string password, string role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
        
        public Account(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Account()
        {
            
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
