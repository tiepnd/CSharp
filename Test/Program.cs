using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Name = "Test";
            Console.WriteLine("Hello World! I'm {0} {1} year old", person.Name,person.Age);
        }
    }
}
