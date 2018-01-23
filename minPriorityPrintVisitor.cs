using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class minPriorityPrintVisitor : IVisitor
    {
        public double FinalValue => throw new NotImplementedException();

        public string Answer {
            get
            {
                string temp = stringBuilder.ToString();
                stringBuilder.Clear();
                return temp;
            }
        }

        private StringBuilder stringBuilder = new StringBuilder();

        private int currentPriority = 0;

        public void Visit(Literal literal)
        {
            stringBuilder.Append(literal.Value);
        }

        public void Visit(Addition addition)
        {
            int temp = currentPriority;
            currentPriority = 1;
            if (temp > 1)
            {
                stringBuilder.Append("(");
            } 
            addition.Children[0].Accept(this);
            stringBuilder.Append("+");
            currentPriority = 1;
            addition.Children[1].Accept(this);
            if (temp > 1)
            {
                stringBuilder.Append(")");
            }
            currentPriority = temp;
        }

        public void Visit(Subtraction subtraction)
        {
            int temp = currentPriority;
            currentPriority = 1;
            if (temp > 1)
            {
                stringBuilder.Append("(");
            }
            subtraction.Children[0].Accept(this);
            stringBuilder.Append("-");
            currentPriority = 2;
            subtraction.Children[1].Accept(this);
            if (temp > 1)
            {
                stringBuilder.Append(")");
            }
            currentPriority = temp;
        }

        public void Visit(Multiplication multiplication)
        {
            int temp = currentPriority;
            currentPriority = 2;
            if (temp > 2)
            {
                stringBuilder.Append("(");
            }
            multiplication.Children[0].Accept(this);
            stringBuilder.Append("*");
            currentPriority = 2;
            multiplication.Children[1].Accept(this);
            if (temp > 2)
            {
                stringBuilder.Append(")");
            }
            currentPriority = temp;
        }

        public void Visit(Division division)
        {
            int temp = currentPriority;
            currentPriority = 2;
            if (temp > 2)
            {
                stringBuilder.Append("(");
            }
            division.Children[0].Accept(this);
            stringBuilder.Append("/");
            division.Children[1].Accept(this);
            currentPriority = 3;
            if (temp > 2)
            {
                stringBuilder.Append(")");
            }
            currentPriority = temp;
        }

        public void Visit(Opposition opposition)
        {
            int temp = currentPriority;
            if (temp > 3)
            {
                stringBuilder.Append("(");
            }
            currentPriority = 3;
            stringBuilder.Append("-");
            opposition.Children[0].Accept(this);
            if (temp > 3)
            {
                stringBuilder.Append(")");
            }
            currentPriority = temp;
        }
    }
}
