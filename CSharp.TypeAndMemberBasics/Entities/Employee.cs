namespace CSharp.TypeAndMemberBasics.Entities
{
    public class Employee : Person
    {
        public override string Greeting()
        {
            const string result = "Employee Greeting";
            return result;
        }
        
        public new string Goodbye()
        {
            const string result = "Employee Goodbye";
            return result;
        }
    }
}