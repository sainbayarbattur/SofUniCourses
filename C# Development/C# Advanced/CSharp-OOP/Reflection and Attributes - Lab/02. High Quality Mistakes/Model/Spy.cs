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

        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();

            var type = Type.GetType($"_1Stealer.Model.{className}");

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            var getters = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(g => g.Name.StartsWith("get"));
            var setters = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(g => g.Name.StartsWith("set"));

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var getter in getters)
            {
                sb.AppendLine($"{getter.Name} must be public!");
            }

            foreach (var setter in setters)
            {
                sb.AppendLine($"{setter.Name} must be private!");
            }

            return sb.ToString();
        }
    }
}