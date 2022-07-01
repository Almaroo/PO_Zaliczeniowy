using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Reflection;
using System.Text;



namespace BlazorJsInteropGenerator
{
    [Generator]
    public class BlazorJsInteropModuleGenerator : ISourceGenerator
    {
        static BlazorJsInteropModuleGenerator()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (_, args) =>
            {
                AssemblyName name = new AssemblyName(args.Name);
                Assembly loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().FullName == name.FullName);
                if (loadedAssembly != null)
                {
                    return loadedAssembly;
                }

                string resourceName = $"BlazorJsInteropGenerator.{name.Name}.dll";

                using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    if (resourceStream == null)
                    {
                        return null;
                    }

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        resourceStream.CopyTo(memoryStream);
                        return Assembly.Load(memoryStream.ToArray());
                    }
                }
            };
        }

        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                //Debugger.Launch();
            }
#endif
            Debug.WriteLine("Initialize Code Generator");
        }

        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource("JsInteropModuleAttribute.g.cs", SourceText.From(GetAttributeText(context.Compilation.Assembly), Encoding.UTF8));

            var indexJsFile = context.AdditionalFiles.Where(at => at.Path.EndsWith(".js")).FirstOrDefault();

            var testModule = new Esprima.JavaScriptParser(indexJsFile.GetText().ToString()).ParseModule();

            var exportedModules =
                testModule.ChildNodes.OfType<Esprima.Ast.ExportNamedDeclaration>().SelectMany(
                    allNodes => allNodes.ChildNodes.OfType<Esprima.Ast.FunctionDeclaration>(),
                    (_, exportNode) => exportNode.Id.Name)
                .ToList();


            string moduleName = $"{context.Compilation.Assembly.Name}Module";
            context.AddSource($"{moduleName}.g.cs", SourceText.From(GetClassSource(context.Compilation.Assembly, moduleName, exportedModules), Encoding.UTF8));
        }

        private string GetClassSource(IAssemblySymbol @namespace, string moduleName, List<string> methodNames)
        {
            string namespaceName = @namespace.Name;

            StringBuilder source = new StringBuilder($@"
using System;
using Microsoft.JSInterop;

namespace {namespaceName}
{{
    [JsInteropModule]
    public partial class {moduleName} : IAsyncDisposable
    {{
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public BlazorLeafletMapModule(IJSRuntime jsRuntime)
        {{
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                ""import"", ""./_content/{namespaceName}/{namespaceName}.js"").AsTask());
        }}

        public static class Methods
        {{
            {string.Join($"{Environment.NewLine}\t\t\t", methodNames.Select(name => $"public static string {name} = \"{name}\";"))}
        }}

        partial void DisposeCustom();

        public async ValueTask DisposeAsync()
        {{
            DisposeCustom();

            if (moduleTask.IsValueCreated)
            {{
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }}
        }}
    }}
}}
");
            return source.ToString();
        }

        //private SourceText AttrText =>
        //    ClassDeclaration("JsInteropModuleAttribute")
        //    .AddAttributeLists(
        //        AttributeList(
        //            Attribute("", 
        //                AttributeArgumentList(
        //                    AttributeArgument(NameEquals("ValidOn"), NameColon(","), Express),
        //                    AttributeArgument(),
        //                    AttributeArgument(),
        //                    )
        //                )
        //            )
        //        )
        //    .AddMembers(
        //        ConstructorDeclaration("JsInteropModuleAttribute")
        //        .AddModifiers(Token(PublicKeyword))
        //    ).GetText();
        private string GetAttributeText(IAssemblySymbol @namespace)
        {
            string namespaceName = @namespace.Name;
            return $@"
using System;
namespace {namespaceName}
{{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class JsInteropModuleAttribute : Attribute
    {{
        public JsInteropModuleAttribute() {{}}
    }}
}}
";
        }
    }
}

