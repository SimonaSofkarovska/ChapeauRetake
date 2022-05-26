using System;

namespace ChapeauModel
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums Role { get; set; }
        public string Password { private get; set; }

        public Employee(int id, string name, Enums role, string password)
        {
            Id = id;
            Name = name;
            Role = role;
            Password = password;
        }
        public Employee()
        {

        }
    }
}
