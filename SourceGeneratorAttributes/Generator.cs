
using System.Text;
using System.Xml.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SourceGeneratorAttributes;


[Generator]
public class Generator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        var output = @"using System;
namespace SourceGeneratorAttributes;
[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
class GlobalAttribute : Attribute
{
    public int OptionalNumber { get; set; } = 10;
    public string OptionalString { get; set; } = ""test"";
    public GlobalAttribute(string requiredString, int requiredNumber) {}
}
";
        context.AddSource("GlobalAttribute.cs", SourceText.From(output, Encoding.UTF8));

        var attributes = context.Compilation.Assembly.GetAttributes();
        foreach (var attribute in attributes)
        {
            Console.WriteLine(attribute);
        }
    }
    public void Initialize(GeneratorInitializationContext context)
    {
    }
}