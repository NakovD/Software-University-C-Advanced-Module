namespace ValidationAttributes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using ValidationAttributes.Attributes.Contracts;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj
                .GetType()
                .GetProperties()
                .Where(p => p.CustomAttributes.Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)));

            var isValid = true;

            foreach (var property in properties)
            {
                var validationAttributes = property.GetCustomAttributes().Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()));
                var propertyValue = property.GetValue(obj);

                foreach (var attr in validationAttributes)
                {
                    var neededMethod = attr.GetType().GetMethod("IsValid", BindingFlags.Public | BindingFlags.Instance);
                    var result = (bool)neededMethod.Invoke(attr, new object[] { propertyValue });
                    if (!result) return false;
                }
            }

            return isValid;
        }

    }
}
