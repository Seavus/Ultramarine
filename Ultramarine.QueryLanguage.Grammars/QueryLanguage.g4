grammar QueryLanguage;

/*
 * Parser Rules
 */

conditioner
	: condition EOF
	;

condition: logical_expression;


logical_expression 
	: logical_expression AND logical_expression
	| logical_expression OR logical_expression
	| comparison_expression
	| LPAREN logical_expression RPAREN
	| logical_entity;

comparison_expression
	: LeftOperand=comparison_operand Operator=comparison_operator RightOperand=comparison_operand
	| LPAREN comparison_expression RPAREN
	;

comparison_operand
	: logical_entity
	;
comparison_operator
	: EQ
	;

logical_entity
	: BooleanEntity=(TRUE | FALSE) #LogicalConst
	| StringEntity=IDENTIFIER	 #LogicalVariable
	;



/*
 * Lexer Rules
 */
AND : 'and';
OR  : 'or';

EQ	: 'equals';

TRUE: 'true';
FALSE: 'false';

LPAREN: '(';
RPAREN: ')';

IDENTIFIER: [a-zA-Z_][a-zA-Z_0-9]* ;

WS
	:	' ' -> channel(HIDDEN)
	;
