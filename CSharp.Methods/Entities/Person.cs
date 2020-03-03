namespace CSharp.Methods.Entities
{
    public abstract class Person
    {
        protected readonly string _name;

        protected Person(string name)
        {
            _name = name;
        }
        
        protected Person() {}
    }
}