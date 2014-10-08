using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace SemanticAnalysisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(@" 
                public static float FindSquareRoot_BS(int number)
                {
                    var precision = 0.0001f;
                    var min = 0;
                    var max = number;
                    var result = 0;
                    while (max-min > precision)
                    {
                        result = (min + max) / 2;
                        if ((result*result) >= number)
                        {
                           max = result;
                        }
                        else
                        {
                           min = result;
                        }
                   }
                   return result;
                }");

            var root = (CompilationUnitSyntax)tree.GetRoot();

            var compilation = CSharpCompilation.Create("sqrt.dll")
             .AddReferences(new MetadataFileReference(typeof(object).Assembly.Location))
             .AddSyntaxTrees(tree);

            var model = compilation.GetSemanticModel(tree);

            foreach(var variable in root.DescendantNodes().OfType<LocalDeclarationStatementSyntax>())
            {
                var typeSymbol = model.GetSymbolInfo(variable.Declaration.Type).Symbol;
                var variableName = variable.DescendantNodes().OfType<VariableDeclaratorSyntax>().First();

                Console.WriteLine("{0,-10}{1}", typeSymbol, variableName);
            }

            Console.ReadLine();
        }
    }
}
