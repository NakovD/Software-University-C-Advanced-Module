
namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Metadata;
    using System.Text;
    using System.Xml.Linq;

    public class Spy
    {

        public string StealFieldInfo(string className, params string[] namesOfFields)
        {
            var sb = new StringBuilder();
            var classData = Type.GetType(className);
            sb.AppendLine($"Class under investigation: {classData.Name}");
            var testInstance = Activator.CreateInstance(classData);

            foreach (var item in namesOfFields)
            {
                var fieldData = classData.GetField(item, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                sb.AppendLine($"{fieldData.Name} = {fieldData.GetValue(testInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var sb = new StringBuilder();
            var typeData = Type.GetType(className);
            var fields = typeData.GetFields(BindingFlags.Instance | BindingFlags.Public);
            var publicMethods = typeData.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var privateMethods = typeData.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var fieldsAnalysis = AnalyzeFields(fields);
            var settersAnalysis = AnalyzeSetters(publicMethods);
            var gettersAnalysis = AnalyzeGetters(privateMethods);

            sb.AppendLine(fieldsAnalysis);
            sb.AppendLine(gettersAnalysis);
            sb.AppendLine(settersAnalysis);

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();
            var typeData = Type.GetType(className);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {typeData.BaseType.Name}");

            var privateMethods = typeData.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).ToList();
            privateMethods.ForEach(pm => sb.AppendLine(pm.Name));

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            var sb = new StringBuilder();
            var typeData = Type.GetType(className);
            var methods = typeData.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var getters = methods.Where(m => m.Name.StartsWith("get_")).ToList();
            var setters = methods.Where(m => m.Name.StartsWith("set_")).ToList();

            getters.ForEach(g => sb.AppendLine($"{g.Name} will return {g.ReturnType}"));
            setters.ForEach(s => sb.AppendLine($"{s.Name} will set field of {s.GetParameters().First().ParameterType}"));
            

            return sb.ToString().Trim();
        }

        private string AnalyzeGetters(MethodInfo[] privateMethods)
        {
            var sb = new StringBuilder();
            var onlyGetters = privateMethods.Where(pm => pm.Name.StartsWith("get"));

            foreach (var item in onlyGetters)
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }

            return sb.ToString().Trim();
        }

        private string AnalyzeSetters(MethodInfo[] publicMethods)
        {
            var sb = new StringBuilder();
            var onlySetters = publicMethods.Where(pm => pm.Name.StartsWith("set"));

            foreach (var item in onlySetters)
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        private string AnalyzeFields(FieldInfo[] fields)
        {
            var sb = new StringBuilder();

            foreach (var item in fields)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
