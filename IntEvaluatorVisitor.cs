using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class IntEvaluatorVisitor : IVisitor
    {
        private int MidValue;

        public double FinalValue => MidValue;

        public string Answer => MidValue.ToString();

        public void Visit(Literal literal)
        {
            MidValue = (int)literal.Value;
        }

        public void Visit(Addition addition)
        {
            int firstValue;
            int secondValue;
            addition.Children[0].Accept(this);
            firstValue = MidValue;
            addition.Children[1].Accept(this);
            secondValue = MidValue;
            MidValue = checked(firstValue + secondValue);
        }

        public void Visit(Subtraction subtraction)
        {
            int firstValue;
            int secondValue;
            subtraction.Children[0].Accept(this);
            firstValue = MidValue;
            subtraction.Children[1].Accept(this);
            secondValue = MidValue;
            MidValue = checked(firstValue - secondValue);
        }

        public void Visit(Multiplication multiplication)
        {
            int firstValue;
            int secondValue;
            multiplication.Children[0].Accept(this);
            firstValue = MidValue;
            multiplication.Children[1].Accept(this);
            secondValue = MidValue;
            MidValue = checked(firstValue * secondValue);
        }

        public void Visit(Division division)
        {
            int firstValue;
            int secondValue;
            division.Children[0].Accept(this);
            firstValue = MidValue;
            division.Children[1].Accept(this);
            secondValue = MidValue;
            MidValue = checked(firstValue / secondValue);
        }

        public void Visit(Opposition opposition)
        {
            opposition.Children[0].Accept(this);
            MidValue = checked(-MidValue);
        }
    }
}
