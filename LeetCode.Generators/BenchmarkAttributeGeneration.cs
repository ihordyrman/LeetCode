using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace LeetCode.Generators;

[Generator(LanguageNames.CSharp)]
public class BenchmarkAttributeGeneration : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
        => context.RegisterPostInitializationOutput(
            ctx =>
            {
                ctx.AddSource(
                    $"{Constants.BenchmarkAttributeName}.g.cs",
                    SourceText.From(
                        $$"""
                          using System;

                          namespace LeetCode.Generators
                          {
                              [AttributeUsage(AttributeTargets.Method)]
                              public class {{Constants.BenchmarkAttributeName}} : Attribute
                              {
                              }
                          }
                          """,
                        Encoding.UTF8));
            });
}
