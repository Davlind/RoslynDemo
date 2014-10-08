using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace SyntaxTreeDemo
{
    class Program
    {
        static void Main()
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(@"kod");

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
