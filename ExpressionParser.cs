using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    static class ExpressionParser
    {
        static string[] tokens;
        static int index = 1;
        static public IExpression ReadFormula(string s)
        {
            index = 1;
            tokens = s.Split();
            if (tokens[0] != "=")
            {
                throw new FormatException();
            }
            IExpression root = ReadPart();
            if (tokens.Length > index+1)
            {
                throw new FormatException();
            }
            return root;
        }

        private static IExpression ReadPart()
        {
            IExpression node;
            List<IExpression> children = new List<IExpression>();
            switch (tokens[index])
            {
                case "+":
                    ++index;
                    children.Add(ReadPart());
                    ++index;
                    children.Add(ReadPart());
                    node = new Addition(children.ToArray());
                    return node;
                case "-":
                    ++index;
                    children.Add(ReadPart());
                    ++index;
                    children.Add(ReadPart());
                    node = new Subtraction(children.ToArray());
                    return node;
                case "*":
                    ++index;
                    children.Add(ReadPart());
                    ++index;
                    children.Add(ReadPart());
                    node = new Multiplication(children.ToArray());
                    return node;
                case "/":
                    ++index;
                    children.Add(ReadPart());
                    ++index;
                    children.Add(ReadPart());
                    node = new Division(children.ToArray());
                    return node;
                case "~":
                    ++index;
                    children.Add(ReadPart());
                    node = new Opposition(children.ToArray());
                    return node;
                default:
                    int value = int.Parse(tokens[index]);
                    node = new Literal(value);
                    return node;
            }
                
        }
    }
}
