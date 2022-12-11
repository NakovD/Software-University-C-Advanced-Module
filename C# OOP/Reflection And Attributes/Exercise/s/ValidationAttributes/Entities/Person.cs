namespace ValidationAttributes.Entities
{
    using ValidationAttributes.Attributes;

    public class Person
    {
        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(12, 90)]
        public int Age { get; private set; }

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
    }
}
