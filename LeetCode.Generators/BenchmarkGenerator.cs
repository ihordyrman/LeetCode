using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace LeetCode.Generators;

public record BenchmarkTypeData(string TypeName, string MethodName, string Namespace);

[Generator(LanguageNames.CSharp)]
public class BenchmarkGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValuesProvider<BenchmarkTypeData> methods = context.SyntaxProvider.ForAttributeWithMetadataName(
                $"LeetCode.Generators.{Constants.BenchmarkAttributeName}",
                IsMethodForExecution,
                GetMethodWithAttribute)
            .Where(x => x is not null)!;

        context.RegisterSourceOutput(methods, GenerateBenchmarkClass);
    }

    private static bool IsMethodForExecution(SyntaxNode node, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        return node is MethodDeclarationSyntax { AttributeLists.Count: > 0 };
    }

    private static BenchmarkTypeData? GetMethodWithAttribute(GeneratorAttributeSyntaxContext context, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (context.TargetSymbol is not IMethodSymbol methodSymbol)
        {
            return null;
        }

        INamedTypeSymbol? type = methodSymbol.ContainingType;

        return new BenchmarkTypeData(type.Name, methodSymbol.Name, type.ContainingNamespace.ToDisplayString());
    }

    private static void GenerateBenchmarkClass(SourceProductionContext context, BenchmarkTypeData typeData)
    {
        context.CancellationToken.ThrowIfCancellationRequested();
        var benchmarkClassName = $"{typeData.TypeName}_{typeData.MethodName}_Benchmark";

        var source = $$"""
                       using BenchmarkDotNet.Attributes;

                       namespace {{typeData.Namespace}}.Benchmarks
                       {
                           public class {{benchmarkClassName}}
                           {
                               private readonly {{typeData.TypeName}} instance = new {{typeData.TypeName}}();

                               [Benchmark]
                               public void Run()
                               {
                                   instance.{{typeData.MethodName}}();
                               }
                           }
                       }
                       """;

        context.AddSource($"{benchmarkClassName}.g.cs", SourceText.From(source, Encoding.UTF8));
    }
}
