namespace OderApp.DataSource.Entities
{
    public class AccountEntity
    {
        public AccountEntity(string email, string password, string role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
