using System;

namespace Deligate
{
    class Program
    {
        public delegate int Caculator(int a, int b);

        static int sum(int a, int b)
        {
            Console.WriteLine("sum");
            return a + b;
        }
        static int mul(int a, int b)
        {
            Console.WriteLine("mul");
            return a * b;
        }

        static void Main(string[] args)
        {
            Caculator caculator = sum;
            caculator += mul;

            Console.WriteLine(caculator.Method.Name+ " " + caculator(2, 4));
        }
    }
}
