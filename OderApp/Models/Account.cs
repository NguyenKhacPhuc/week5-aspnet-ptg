namespace OderApp.Models
{
    public class Account
    {
        public Account(string email, string password, int decentralization)
        {
            Email = email;
            Password = password;
            Decentralization = decentralization;
        }

        public Account()
        {
            
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Decentralization { get; set; }
    }
}
