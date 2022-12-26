namespace OderApp.Models
{
    public class User
    {
        public string Id { set; get; }

        public string Name { set; get; }

        public string Email { set; get; }

        public int Role { set; get; }

        public User()
        {
        }
        public User(string name, string email, int role)
        {
            Id = generateId().ToString();
            Name = name;
            Email = email;
            Role = role;
        }
        public User(string id, string name, string email, int role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }
        
        static int generateId()
        {
            return new Random().Next();
        }
    }

    public enum Role
    {
        Admin = 0,
        Customer = 1
    }
}

