namespace CSharp.TypeFundamentals.Entities
{
    public class Employee : EmployeeParent
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int GetYearsEmployed()
        {
            const int result = 5;
            return result;
        }

        public virtual string GetProgressReport()
        {
            const string result = "employee progress report";
            return result;
        }

        public static Employee Lookup(string name)
        {
            var result = new Manager("Joe");
            return result;
        }
    }
}