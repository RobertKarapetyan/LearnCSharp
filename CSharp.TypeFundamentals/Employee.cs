namespace CSharp.TypeFundamentals
{
    public class Employee : EmployeeParent
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}