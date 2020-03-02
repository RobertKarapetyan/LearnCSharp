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

        public int AgeOfThePerson()
        {
            var result = GetAge();
            return result;
        }

        protected sealed override int GetAge()
        {
            var result = base.GetAge();
            return result;
        }

        public new string GetPersonName()
        {
            var result = base.GetName();
            return result;
        }
    }
}