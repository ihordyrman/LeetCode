using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace LeetCode.Generators;

public record BenchmarkMethodData(string TypeName, string MethodName, string Namespace);

[Generator(LanguageNames.CSharp)]
public class BenchmarkGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<BenchmarkMethodData> methods = context.SyntaxProvider.ForAttributeWithMetadataName(
                "LeetCode.Generators.ExecutableAttribute",
                predicate: IsMethodForExecution,
                transform: GetMethodWithAttribute)
            .Where(x => x is not null)!;

        context.RegisterSourceOutput(methods, GenerateBenchmarkClass);
    }

    private static bool IsMethodForExecution(SyntaxNode node, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return node is MethodDeclarationSyntax { AttributeLists.Count: > 0 };
    }

    private static BenchmarkMethodData? GetMethodWithAttribute(GeneratorAttributeSyntaxContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (context.TargetSymbol is not IMethodSymbol methodSymbol)
        {
            return null;
        }

        INamedTypeSymbol? type = methodSymbol.ContainingType;

        return new BenchmarkMethodData(
            TypeName: type.Name,
            MethodName: methodSymbol.Name,
            Namespace: type.ContainingNamespace.ToDisplayString());
    }

    private static void GenerateBenchmarkClass(SourceProductionContext context, BenchmarkMethodData methodData)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        var benchmarkClassName = $"{methodData.TypeName}_{methodData.MethodName}_Benchmark";

        var source = $$"""
                       using BenchmarkDotNet.Attributes;

                       namespace {{methodData.Namespace}}.Benchmarks
                       {
                           public class {{benchmarkClassName}}
                           {
                               private readonly {{methodData.TypeName}} instance = new {{methodData.TypeName}}();

                               [Benchmark]
                               public void Run()
                               {
                                   instance.{{methodData.MethodName}}();
                               }
                           }
                       }
                       """;

        context.AddSource($"{benchmarkClassName}.g.cs", SourceText.From(source, Encoding.UTF8));
    }
}
