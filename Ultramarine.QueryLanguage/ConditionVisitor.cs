using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class ConditionVisitor : QueryLanguageBaseVisitor<Condition>
    {
        public ConditionVisitor()
        {
            Conditions = new List<Condition>();
        }
        public List<Condition> Conditions { get; set; }

        public override Condition VisitComparison_expression([NotNull] QueryLanguageParser.Comparison_expressionContext context)
        {
            var condition = new Condition(context.Operator.GetText(), context.LeftOperand.GetText(), context.RightOperand.GetText());

            Conditions.Add(condition);

            return condition;
        }        
    }
}
