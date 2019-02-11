using System;
using System.Text;

namespace MockPerformance
{
    class Program
    {
        public const string ClassTemplate =
            @"using System;

namespace MockPerformance
{{
    public class BloatedClass 
    {{
    {0}
    }}
}}";

        private static void GenerateClass()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < 3000; i++)
            {
                sb.AppendLine($"{Environment.NewLine}            public Object Propery{i} {{ get; set; }}");
                sb.AppendLine($"{Environment.NewLine}            public void Method{i} (Object obj) {{ }}");
            }

            var code = String.Format(ClassTemplate, sb);
            System.IO.File.WriteAllText(@"C:\sources\MockPerformance\MockPerformance\BloatedClass.cs", code);
        }

        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
