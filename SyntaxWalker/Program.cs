using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace SyntaxWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(
                  @"...kod...");

            var root = (CompilationUnitSyntax)tree.GetRoot();

            var cyclomaticComplexityWalker = new CyclomaticComplexityWalker();
            cyclomaticComplexityWalker.Visit(root);

            Console.ReadLine();
        }
    }
}
