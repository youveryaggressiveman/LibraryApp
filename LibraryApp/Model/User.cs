using System;
using System.Collections.Generic;

#nullable disable

namespace LibraryApp.Model
{
    public partial class User
    {
        public User() { }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<RoleOfUser> RoleOfUsers { get; set; }
    }
}
