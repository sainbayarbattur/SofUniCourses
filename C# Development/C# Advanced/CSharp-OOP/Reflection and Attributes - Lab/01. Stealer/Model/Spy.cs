namespace _1Stealer.Model
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Reflection;

    public class Spy
    {
        public string StealFieldInfo(string name, params string[] fieldsToInvestigate)
        {
            var sb = new StringBuilder();

            var type = Type.GetType($"_1Stealer.Model.{name}");

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            var instance = Activator.CreateInstance(type);

            sb.AppendLine($"Class under investigation: {name}");

            foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine(field.Name + " = " + field.GetValue(instance));
            }

            return sb.ToString();
        }
    }
}