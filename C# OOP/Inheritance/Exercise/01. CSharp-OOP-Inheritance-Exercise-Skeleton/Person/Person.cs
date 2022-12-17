using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        public string Name { get; set; }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0) return;
                this.age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}, Age: {this.Age}");
            return sb.ToString().Trim();
        }
    }
}
