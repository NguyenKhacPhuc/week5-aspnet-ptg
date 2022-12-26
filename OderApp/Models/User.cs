namespace OderApp.Models
{
    public class User
    {
        public string Id { set; get; }

        public string Name { set; get; }

        public string Email { set; get; }

        public int Role { set; get; }

        public User(string id, string name, string email, int role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }
    }

    public enum Role
    {
        Admin = 0,
        Customer = 1
    }
}

