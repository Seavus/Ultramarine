using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Ultramarine.QueryLanguage.Grammars;

namespace Ultramarine.QueryLanguage
{
    public class Validator
    {
        public Validator(string expression)
        {
            //TODO: rethink
        }
    }

    public class ConditionVisitor : QueryLanguageBaseVisitor<Condition>
    {
        public ConditionVisitor()
        {
            Conditions = new List<Condition>();
        }
        public List<Condition> Conditions { get; set; }

        public override Condition VisitComparison_expression([NotNull] QueryLanguageParser.Comparison_expressionContext context)
        {
            var operands = context.comparison_operand();
            var comparisonOperator = context.comparison_operator();

            var condition = new Condition(comparisonOperator.GetText(), operands[0].GetText(), operands[1].GetText());

            Conditions.Add(condition);

            return condition;
            //return base.VisitComparison_expression(context);
        }
    }
}
