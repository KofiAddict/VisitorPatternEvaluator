using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    interface IExpression
    {
        IExpression[] Children { get; }
        double Value { get; set; }
        void Accept(IVisitor visitor);
    }

    class Addition : IExpression
    {
        public Addition(IExpression[] children)
        {
            Children = children;
        }
        public IExpression[] Children { get; }
        public double Value { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Division : IExpression
    {
        public Division(IExpression[] children)
        {
            Children = children;
        }
        public double Value { get; set; }
        public IExpression[] Children { get; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Literal : IExpression
    {
        public Literal(double value)
        {
            Value = value;
        }
        public double Value { get; set; }
        public IExpression[] Children => null;
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Multiplication : IExpression
    {
        public Multiplication(IExpression[] children)
        {
            Children = children;
        }
        public double Value { get; set; }
        public IExpression[] Children { get; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Opposition : IExpression
    {
        public Opposition(IExpression[] children)
        {
            Children = children;
        }
        public double Value { get; set; }
        public IExpression[] Children { get; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Subtraction : IExpression
    {
        public Subtraction(IExpression[] children)
        {
            Children = children;
        }
        public double Value { get; set; }
        public IExpression[] Children { get; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
