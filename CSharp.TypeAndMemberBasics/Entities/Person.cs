namespace CSharp.TypeAndMemberBasics.Entities
{
    public class Person
    {
        private int _age;
        private string _name;

        public void SetName(string name)
        {
            _name = name;
        }

        protected string GetName()
        {
            var result = _name;
            return _name;
        }

        public void SetAge(int age)
        {
            _age = age;
        }

        protected virtual int GetAge()
        {
            var result = _age;
            return result;
        }
        
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