using Moq;
using Rhino.Mocks;
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
                sb.AppendLine($"\r\n            public Object Propery{i} {{ get; set; }}");
                sb.AppendLine($"\r\n            public void Method{i} (Object obj) {{ }}");
            }
            var code = String.Format(ClassTemplate, sb);
            System.IO.File.WriteAllText(@"C:\sources\MockPerformance\MockPerformance\BloatedClass.cs", code);
        }


        public interface IA
        {
            BloatedClass Test(BloatedClass b); // B is a crazy large object with ~2700 properties with backing fields
        }

        private static IA CreateRhinoMock()
        {
            var mock = MockRepository.GenerateMock<IA>();
            mock.Stub(m => m.Test(Arg<BloatedClass>.Is.Anything)).Do(a => a);
            return mock;
        }

        private static IA CreateMoqMock()
        {
            var mock = new Mock<IA>();
            mock.Setup(m => m.Test(It.IsAny<BloatedClass>())).Returns(new BloatedClass());
            return mock.Object;
        }


        static void Main(string[] args)
        {



            Console.ReadKey();
        }
    }
}
