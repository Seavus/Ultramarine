grammar QueryLanguage;

/*
 * Parser Rules
 */

conditioner
	: condition EOF
	;

condition: logical_expression;

/*
 * Lexer Rules
 */
AND : 'and';
OR  : 'or';

EQ	: 'equals';

TRUE: 'true';
FALSE: 'false';

IDENTIFIER: [a-zA-Z_][a-zA-Z_0-9]* ;


logical_expression 
	: logical_expression AND logical_expression
	| logical_expression OR logical_expression
	| comparison_expression
	| logical_entity;

comparison_expression
	: comparison_operand comparison_operator comparison_operand
	;

comparison_operand
	: IDENTIFIER
	;
comparison_operator
	: EQ
	;

logical_entity
	: (TRUE | FALSE)
	| IDENTIFIER
	;

WS
	:	' ' -> channel(HIDDEN)
	;
