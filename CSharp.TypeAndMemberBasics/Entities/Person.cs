namespace CSharp.TypeAndMemberBasics.Entities
{
    public class Person
    {
        public virtual string Greeting()
        {
            const string result = "Person Greeting";
            return result;
        }

        public string Goodbye()
        {
            const string result = "Person Goodbye";
            return result;
        }
    }
}