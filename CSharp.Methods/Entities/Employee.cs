namespace CSharp.Methods.Entities
{
    public class Employee : Person
    {
        public string EmployeeId { get; set; }

        public Employee(string name) : base(name)
        {
        }

        public Employee()
        {
        }

        public string Name()
        {
            var result = _name;
            return result;
        }

        public Employee CloneEmployeeByMembers()
        {
            var result = (Employee) MemberwiseClone();
            return result;
        }
    }
}