using Microsoft.CSharp;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Rees.TangyFruitMapper.UnitTest
{
    internal class DynamicCodeCompiler
    {
        public IDtoMapper<TDto, TModel>? CompileMapperCode<TDto, TModel>(string code, ITestOutputHelper output)
        {
            //var provider = new CSharpCodeProvider();
            //var parameters = new CompilerParameters();
            //parameters.ReferencedAssemblies.Add("Rees.TangyFruitMapper.dll");
            //parameters.ReferencedAssemblies.Add("System.dll");
            //parameters.ReferencedAssemblies.Add("System.Core.dll");
            //parameters.ReferencedAssemblies.Add("System.Runtime.dll");
            //parameters.ReferencedAssemblies.Add("System.Linq.dll");
            //parameters.ReferencedAssemblies.Add("Rees.TangyFruitMapper.UnitTest.dll");
            //// True - memory generation, false - external file generation
            //parameters.GenerateInMemory = true;
            //// True - exe file generation, false - dll file generation
            //parameters.GenerateExecutable = false;
            //var results = provider.CompileAssemblyFromSource(parameters, code);
            //if (results.Errors.HasErrors)
            //{
            //    foreach (CompilerError error in results.Errors)
            //    {
            //        output.WriteLine($"Error ({error.ErrorNumber}): {error.ErrorText}");
            //    }
            //    throw new XunitException("Error compiling the generated mapper code.");
            //}
            //var assembly = results.CompiledAssembly;
            //var mapperType = assembly.GetType($"GeneratedCode.Mapper_{typeof(TDto).Name}_{typeof(TModel).Name}");
            //return (IDtoMapper<TDto, TModel>)mapperType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            // TODO
            return null;
            // FROM Co-pilot:
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.Emit;
//using System;
//using System.IO;
//using System.Reflection;
//using System.Runtime.Loader;

//public class DynamicCodeCompiler
//{
//    public static Assembly CompileAndLoadAssembly(string code)
//    {
//        var syntaxTree = CSharpSyntaxTree.ParseText(code);

//        var assemblyName = Path.GetRandomFileName();
//        var references = new MetadataReference[]
//        {
//            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
//            MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
//            // Add other necessary references here
//        };

//        var compilation = CSharpCompilation.Create(
//            assemblyName,
//            new[] { syntaxTree },
//            references,
//            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

//        using (var ms = new MemoryStream())
//        {
//            EmitResult result = compilation.Emit(ms);

//            if (!result.Success)
//            {
//                // Handle compilation failures
//                return null;
//            }

//            ms.Seek(0, SeekOrigin.Begin);
//            return AssemblyLoadContext.Default.LoadFromStream(ms);
//        }
//    }
//}
        }
    }
}
