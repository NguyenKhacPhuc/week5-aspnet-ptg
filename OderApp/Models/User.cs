using System;
namespace OderApp.Models
{
    public class User
    {
        public string Id { set; get; }

        public string Name { set; get; }

        public string Email { set; get; }

        public Role Role { set; get; }

        public User(string id, string name, string email, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }
    }

    public enum Role
    {
        Admin,
        Customer
    }
}

