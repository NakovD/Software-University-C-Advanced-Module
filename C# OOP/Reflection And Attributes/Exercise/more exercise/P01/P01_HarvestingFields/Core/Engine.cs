namespace P01_HarvestingFields.Core
{
    using P01_HarvestingFields.Core.Contracts;
    using P01_HarvestingFields.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Engine : IEngine
    {
        private IReader reader;

        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var line = reader.ReadLine();

            while (line != "HARVEST")
            {
                var type = typeof(HarvestingFields);
                var fields = GetNeededFields(line, type);
                LogFields(fields);
                line = reader.ReadLine();
            }
        }

        private FieldInfo[] GetNeededFields(string line, Type type)
        {
            var neededFlag = GetFlag(line);
            var fields = type.GetFields(neededFlag);
            if (line == "protected") fields = fields.Where(f => f.IsFamily).ToArray();
            if (line == "private") fields = fields.Where(f => !f.IsFamily).ToArray();
            return fields;
        }

        private void LogFields(FieldInfo[] fields)
        {
            foreach (var item in fields)
            {
                var accessModifier = GetAccessModifier(item);
                writer.WriteLine($"{accessModifier} {item.FieldType.Name} {item.Name}");
            }
        }

        private string GetAccessModifier(FieldInfo item)
        {
            if (item.IsPrivate && !item.IsFamily) return "private";
            if (item.IsFamily) return "protected";
            else if (item.IsPublic) return "public";

            return "";
        }

        private BindingFlags GetFlag(string type)
        {
            switch (type)
            {
                case "private": return BindingFlags.NonPublic | BindingFlags.Instance;
                case "protected": return BindingFlags.NonPublic | BindingFlags.Instance;
                case "public": return BindingFlags.Public | BindingFlags.Instance;
                default: return BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            }
        }
    }
}
