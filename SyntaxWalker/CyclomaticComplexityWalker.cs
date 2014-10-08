using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace SyntaxWalker
{
    class CyclomaticComplexityWalker : CSharpSyntaxWalker
    {
        private int complexity = 0;
    }
}
