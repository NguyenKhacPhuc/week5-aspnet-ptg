using System;
namespace OderApp.DataSource.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public UserEntity(string id, string name, string email, Role role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        public UserEntity()
        {
           
        }
    }

    public enum Role
    {
        Admin,
        Customer
    }
}

