using Microsoft.CSharp;
using Xunit.Abstractions;
using Xunit.Sdk;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Rees.TangyFruitMapper.UnitTest
{
    internal class DynamicCodeCompiler
    {
        public IDtoMapper<TDto, TModel>? CompileMapperCode<TDto, TModel>(string code, ITestOutputHelper output)
        {
            var assembly = CompileAndLoadAssembly(code, x => output.WriteLine(x));
            var mapperType = assembly.GetType($"GeneratedCode.Mapper_{typeof(TDto).Name}_{typeof(TModel).Name}");
            return (IDtoMapper<TDto, TModel>)mapperType.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

        public static Assembly CompileAndLoadAssembly(string code, Action<string> log)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);

            var assemblyName = Path.GetRandomFileName();
            var runningFolder = typeof(DynamicCodeCompiler).Assembly.Location;
            var references = new MetadataReference[]
            {
                    Basic.Reference.Assemblies.Net80.References.SystemRuntime,
                    Basic.Reference.Assemblies.Net80.References.SystemLinq,
                    Basic.Reference.Assemblies.Net80.References.SystemConsole,
                    Basic.Reference.Assemblies.Net80.References.SystemCollections,
                    MetadataReference.CreateFromFile(runningFolder),  // Complete path to this unit test library.
                    MetadataReference.CreateFromFile($"{Path.GetDirectoryName(runningFolder)}\\Rees.TangyFruitMapper.dll"), 
                // Add other necessary references here
            };
            //parameters.ReferencedAssemblies.Add("Rees.TangyFruitMapper.dll");
            //parameters.ReferencedAssemblies.Add("Rees.TangyFruitMapper.UnitTest.dll");

            var compilation = CSharpCompilation.Create(
                assemblyName,
                new[] { syntaxTree },
                references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    // Handle compilation failures
                    foreach (Diagnostic diagnostic in result.Diagnostics)
                    {
                        log(diagnostic.ToString());
                    }
                    return null;
                }

                ms.Seek(0, SeekOrigin.Begin);
                return AssemblyLoadContext.Default.LoadFromStream(ms);
            }
        }
    }
}
