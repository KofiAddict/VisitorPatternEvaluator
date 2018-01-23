using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class DoubleEvaluatorVisitor : IVisitor
    {
        private double MidValue;

        public double FinalValue => MidValue;

        public string Answer => MidValue.ToString("f05");

        public void Visit(Literal literal)
        {
            MidValue = literal.Value;
        }

        public void Visit(Addition addition)
        {
            double firstValue;
            double secondValue;
            addition.Children[0].Accept(this);
            firstValue = MidValue;
            addition.Children[1].Accept(this);
            secondValue = MidValue;
            MidValue = checked(firstValue + secondValue);
        }

        public void Visit(Subtraction subtraction)
        {
            double firstValue;
            double secondValue;
            subtraction.Children[0].Accept(this);
            firstValue = MidValue;
            subtraction.Children[1].Accept(this);
            secondValue = MidValue;
            MidValue = checked(firstValue - secondValue);
        }

        public void Visit(Multiplication multiplication)
        {
            double firstValue;
            double secondValue;
            multiplication.Children[0].Accept(this);
            firstValue = MidValue;
            multiplication.Children[1].Accept(this);
            secondValue = MidValue;
            MidValue = checked(firstValue * secondValue);
        }

        public void Visit(Division division)
        {
            double firstValue;
            double secondValue;
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
