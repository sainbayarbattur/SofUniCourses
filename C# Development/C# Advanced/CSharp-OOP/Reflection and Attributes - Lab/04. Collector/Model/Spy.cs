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

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            var type = Type.GetType($"_1Stealer.Model.{className}");

            var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }
            
            return sb.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();

            var type = Type.GetType($"_1Stealer.Model.{className}");

            var allMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            var getters = allMethods.Where(g => g.Name.StartsWith("get"));
            var setters = allMethods.Where(g => g.Name.StartsWith("set"));

            foreach (var getter in getters)
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (var setter in setters)
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString();
        }
    }
}