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

            var implicitVariables =
                from variableDeclaration in root.DescendantNodes()
                                                .OfType<LocalDeclarationStatementSyntax>()
                from implicitVariable in variableDeclaration.DescendantNodes()
                                                            .OfType<IdentifierNameSyntax>()
                where implicitVariable.Identifier.ValueText == "var"
                select implicitVariable;

            Console.WriteLine("Found {0} implicit variables", implicitVariables.Count());
            Console.ReadLine();
        }
    }
}
