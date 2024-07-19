using Xunit;
using Xunit.Abstractions;

namespace Rees.TangyFruitMapper.UnitTest
{
    public class DynamicCodeCompilerTest
    {
        private readonly ITestOutputHelper output;

        public DynamicCodeCompilerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DynamicCodeCompilerShouldGenerateRunnableAssembly()
        {
            var code = @"
    public class TestClass1
    {
        public string Foo { get; set; }

        public void DoWork(int number)
        {
            System.Console.WriteLine($""{Foo}\n\rDoing work { number}\n"");
        }
    }
";
            var assembly = DynamicCodeCompiler.CompileAndLoadAssembly(code, Console.WriteLine);
            var type = assembly.GetType("TestClass1");
            var testResult = Activator.CreateInstance(type);
            type.GetProperty("Foo").SetValue(testResult, "Hello, World!");
            type.GetMethod("DoWork").Invoke(testResult, new object[] { 42 });
        }
    }
}
