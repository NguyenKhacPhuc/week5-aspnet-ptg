namespace OderApp.DataSource.Entities
{
    public class AccountEntity
    {
        public AccountEntity(string email, string password, int decentralization)
        {
            Email = email;
            Password = password;
            Decentralization = decentralization;
        }

        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public int Decentralization { get; set; }
    }
}
