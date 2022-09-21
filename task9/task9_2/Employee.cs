using System;

namespace task9_2
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Employee()
        {

        }

        public Employee(string name)
        {
            Id = Guid.NewGuid();
            string[] ch = name.Split(' ');
            FirstName = ch[0];
            LastName = ch[1];
            Email = GetEmail();
        }

        private string GetEmail() => FirstName.ToLower() + LastName.ToLower() + "@issoft.by";

        public override string ToString() => $"{FirstName} {LastName} - {Email}";

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   FirstName == employee.FirstName &&
                   LastName == employee.LastName &&
                   Email == employee.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Email);
        }
    }
}
