using Microsoft.CodeAnalysis.CSharp;
using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SyntaxWalker
{
    class CyclomaticComplexityWalker : CSharpSyntaxWalker
    {
        private int complexity = 0;

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            Console.WriteLine(node.Identifier.ValueText);
            base.VisitClassDeclaration(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            complexity = 1;

            base.VisitMethodDeclaration(node);

            Console.WriteLine("\t{0}\t\tCyclomatic Complexity: {1}", node.Identifier.ValueText, complexity);
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            complexity++;
            base.VisitIfStatement(node);
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            complexity++;
            base.VisitWhileStatement(node);
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            complexity++;
            base.VisitForEachStatement(node);
        }

        public override void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            complexity++;
            base.VisitCaseSwitchLabel(node);
        }

        public override void VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            complexity++;
            base.VisitDefaultSwitchLabel(node);
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            complexity++;
            base.VisitContinueStatement(node);
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            complexity++;
            base.VisitGotoStatement(node);
        }

        public override void VisitCatchClause(CatchClauseSyntax node)
        {
            complexity++;
            base.VisitCatchClause(node);
        }
    }
}
