namespace OderApp.DataSource.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Role { get; set; }

        public UserEntity(string name, string email, int role)
        {
            Id = generateId().ToString();
            Name = name;
            Email = email;
            Role = role;
        }

        public UserEntity(string id, string name, string email, int role)
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

