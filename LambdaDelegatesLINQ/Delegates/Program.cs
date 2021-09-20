using Delegates.Entities;
using System;

namespace Delegates
{
    delegate double BinaryNumericOperation(double n1, double n2);
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            //por ser type safety o delegate BinaryNumericOperation só pode receber dois doubles e retornar outro double, como indicado na linha 6
            //Max e Sum funcionam, Square não

            //BinaryNumericOperation op = new BinaryNumericOperation(CalculationService.Sum);
            // double result = op(a, b);

            BinaryNumericOperation op = CalculationService.Sum;
            double result = op.Invoke(a, b);
            
            Console.WriteLine(result);
        }
    }
}
