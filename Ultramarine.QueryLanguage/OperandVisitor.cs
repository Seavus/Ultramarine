using Antlr4.Runtime.Misc;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class OperandVisitor : QueryLanguageBaseVisitor<string>
    {
        public override string VisitComparison_operand([NotNull] QueryLanguageParser.Comparison_operandContext context)
        {
            return context.GetText();
        }
    }


}
