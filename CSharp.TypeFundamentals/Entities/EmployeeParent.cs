namespace CSharp.TypeFundamentals
{
    public class EmployeeParent
    {
        public EmployeeParent()
        {
        }

        public EmployeeParent(int employeeParentId)
        {
            EmployeeParentId = employeeParentId;
        }

        public int EmployeeParentId { get; }
    }
}