namespace ValidationAttributes.Core.Models
{
    using System.Linq;
    using System.Reflection;

    public class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Select(a => (MyValidationAttribute)a)
                    .ToArray();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}