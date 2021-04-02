using System;
using System.Collections.Generic;

namespace GenericExtensionMethod
{
    /// <summary>
    /// Triển khai 1 extension method
    /// </summary>
    public static class ListExtensionMethod
    {
        public static T getRandomElement<T>(this List<T> list)
        {
            Random random = new Random();
            int ranNumber = random.Next(list.Count);
            return list[ranNumber];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2, b = 3;
            swap(ref a, ref b);
            Console.WriteLine($"a: {a}, b: {b}");

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<double> doubles = new List<double>() { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7, 8.8, 9.9 };
            Console.WriteLine($"Random: {numbers.getRandomElement()}");
            Console.WriteLine($"Random: {getRandomElement(doubles)}");
        }

        static void swap<G>(ref G g1, ref G g2)
        {
            G g = g1;
            g1 = g2;
            g2 = g;
        }

        static T getRandomElement<T>(List<T> list)
        {
            Random random = new Random();
            int randomNumber = random.Next(list.Count);
            return list[randomNumber];
        }

    }
}
