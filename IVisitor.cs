using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    interface IVisitor
    {
        double FinalValue { get; }
        string Answer { get; }
        void Visit(Literal literal);
        void Visit(Addition addition);
        void Visit(Subtraction subtraction);
        void Visit(Multiplication multiplication);
        void Visit(Division division);
        void Visit(Opposition opposition);

    }
}
