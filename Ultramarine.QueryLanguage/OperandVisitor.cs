using Antlr4.Runtime.Misc;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class OperandVisitor : QueryLanguageBaseVisitor<string>
    {
        public override string VisitLogicalVariable([NotNull] QueryLanguageParser.LogicalVariableContext context)
        {
            return context.IDENTIFIER().GetText();
        }

        public override string VisitLogicalConst([NotNull] QueryLanguageParser.LogicalConstContext context)
        {
            return context.GetText();
        }
    }


}
