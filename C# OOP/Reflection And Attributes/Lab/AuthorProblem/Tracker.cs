
namespace AuthorProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var currentTypeMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static).ToList();
            var methodsWithAuthor = currentTypeMethods.Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)));

            foreach (var method in currentTypeMethods)
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (AuthorAttribute attr in attributes)
                {
                    Console.WriteLine($"{method.Name} is writter by {attr.Name}");
                }
            }
        }
    }
}
