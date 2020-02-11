using CSharp.TypeFundamentals.Entities;

namespace CSharp.TypeFundamentals
{
    public class Manager : Employee
    {
        public Manager(string name) : base(name)
        {
        }

        public int MaangerId { get; set; }

        public int GetYearsEmployed()
        {
            const int result = 2;
            return result;
        }

        public override string GetProgressReport()
        {
            var result = "manager progress report";
            return result;
        }
    }
}