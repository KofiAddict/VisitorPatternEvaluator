# VisitorPatternEvaluator

The goal is write a program capable of serving as a simple expression calculator. The program processes commands from standard input and 
prints results (or error messages) to standard output. There is only one command per line (ignore empty lines). Commands are processed 
sequentially; the previous command is fully executed before the next one starts loading. The calculator should terminate after it 
processes all input data (attempting to read a line results in null), or when it encounters a line containing only the string "end". The 
calculator recognizes the following commands:

A line starting with the "=" symbol followed by exactly one space and an expression in preorder format (see below). Such a line should be
interpreted by parsing the expression and storing it; following operations will be done over the last parsed expression. If an expression
was already stored, the previous expression should be discarded and replaced by the new expression. The previous expression will be 
discarded even if an error was encountered when processing the "=" command.

A single string "i" should be interpreted by evaluating the last expression using integer arithmetic and printing out the result (one 
integer) on a single output line.

A single string "d" should be interpreted by evaluating the last expression using double-precision floating-point arithmetic (64 bits) and
printing out the result on a single output line using 5 decimal places.

A single string "p" should be interpreted by printing out a line containing the last expression in infix notation, while explicitly 
denoting the operator priorities by enclosing each individual operator and its operands in parentheses (which implies that even the whole 
expression is contained in parentheses).

A single string "P" should be interpreted by printing out a line containing the last expression in infix notation, while using minimal 
number of parentheses. That is, parentheses will only be used to enclose those operations that would otherwise have lower priority than 
required for the infix representation to correspond with the loaded expression when evaluated using standard arithmetic rules. The highest 
operator priority is assigned to unary minus, followed by multiplication and division, with addition and subtraction having the lowest 
priority. We also assume left-associativity when evaluating the expression, i.e. a sequence of operators with the same priority is applied
from left to right.
