using System;

namespace ChapeauModel
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Roles { get; set; }
        public string Password { private get; set; }

        public Employee(int id, string name, Role roles, string password)
        {
            Id = id;
            Name = name;
            Roles = roles;
            Password = password;
        }
        public Employee()
        {

        }
    }
}
