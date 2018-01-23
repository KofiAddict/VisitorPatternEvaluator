using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class AllPriorityPrintVisitor : IVisitor
    {
        public double FinalValue => throw new NotImplementedException();

        public string Answer
        {
            get
            {
                string temp = stringBuilder.ToString();
                stringBuilder.Clear();
                return temp;
            }
        }

        private StringBuilder stringBuilder = new StringBuilder();

        public void Visit(Literal literal)
        {
            
            stringBuilder.Append(literal.Value);
        }

        public void Visit(Addition addition)
        {
            stringBuilder.Append("(");
            addition.Children[0].Accept(this);
            stringBuilder.Append("+");
            addition.Children[1].Accept(this);
            stringBuilder.Append(")");
        }

        public void Visit(Subtraction subtraction)
        {
            stringBuilder.Append("(");
            subtraction.Children[0].Accept(this);
            stringBuilder.Append("-");
            subtraction.Children[1].Accept(this);
            stringBuilder.Append(")");
        }

        public void Visit(Multiplication multiplication)
        {
            stringBuilder.Append("(");
            multiplication.Children[0].Accept(this);
            stringBuilder.Append("*");
            multiplication.Children[1].Accept(this);
            stringBuilder.Append(")");
        }

        public void Visit(Division division)
        {
            stringBuilder.Append("(");
            division.Children[0].Accept(this);
            stringBuilder.Append("/");
            division.Children[1].Accept(this);
            stringBuilder.Append(")");
        }

        public void Visit(Opposition opposition)
        {
            stringBuilder.Append("(");
            stringBuilder.Append("-");
            opposition.Children[0].Accept(this);
            stringBuilder.Append(")");
        }
    }
}
