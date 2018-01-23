using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static IVisitor doubleVisitor = new DoubleEvaluatorVisitor();
        static IVisitor intVisitor = new IntEvaluatorVisitor();
        static IVisitor allPriorPrintVisitor = new AllPriorityPrintVisitor();
        static IVisitor minPriorPrintVisitor = new minPriorityPrintVisitor();
        static void Main(string[] args)
        {
            string Command;
            IExpression root = null;
            while ((Command = Console.ReadLine()) != "end")
            {
                switch (Command)
                {
                    case "i":
                        try
                        {
                            root.Accept(intVisitor);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Expression Missing");
                            break;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Overflow Error");
                            break;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Divide Error");
                            break;
                        }
                        Console.WriteLine(intVisitor.Answer);
                        break;
                    case "d":
                        try
                        {
                            root.Accept(doubleVisitor);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Expression Missing");
                            break;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Overflow Error");
                            break;
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Divide Error");
                            break;
                        }
                        if (Double.IsPositiveInfinity(doubleVisitor.FinalValue))
                        {
                            Console.WriteLine("Infinity");
                        }
                        else if (Double.IsNegativeInfinity(doubleVisitor.FinalValue))
                        {
                            Console.WriteLine("-Infinity");
                        }
                        else
                        {
                            Console.WriteLine(doubleVisitor.Answer);
                        }
                        break;
                    case "p":
                        try
                        {
                            root.Accept(allPriorPrintVisitor);
                            Console.WriteLine(allPriorPrintVisitor.Answer);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Expression Missing");
                            break;
                        }
                        break;
                    case "P":
                        try
                        {
                            root.Accept(minPriorPrintVisitor);
                            Console.WriteLine(minPriorPrintVisitor.Answer);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Expression Missing");
                            break;
                        }
                        break;
                    case "":
                        break;
                    default:
                        try
                        {
                            root = ExpressionParser.ReadFormula(Command);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Format Error");
                            root = null;
                            break;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Format Error");
                            root = null;
                            break;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Format Error");
                            root = null;
                            break;
                        }
                        catch (NullReferenceException)
                        {
                            return;
                        }

                        break;
                }
                

            }

        }
    }
}
