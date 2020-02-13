namespace CSharp.TypeFundamentals.Entities
{
    public class Manager : Employee
    {
        public Manager(string name) : base(name)
        {
        }

        public new int GetYearsEmployed()
        {
            const int result = 2;
            return result;
        }

        public override string GetProgressReport()
        {
            const string result = "manager progress report";
            return result;
        }
    }
}