using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using static System.Console;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Person person = new Person() { Name = "Ten ", Age = 20 })
            {
               
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();   
                //person.Name = "Hello World!";
                // WriteLine(person.Name);
                //stopwatch.Stop();
                // WriteLine("step 1: " + stopwatch.ElapsedMilliseconds);
                //stopwatch.Restart();

                //stopwatch.Stop();

                // WriteLine("reset tesst: " + stopwatch.ElapsedMilliseconds);
                //stopwatch.Restart();
                //File.AppendAllText("person.txt", person.Name + "\n");
                //stopwatch.Stop();
                // WriteLine("step 2: " + stopwatch.ElapsedMilliseconds);

                //Person test = null;
                //test = person ?? new Person() { Name = "Name ", Age = 20 };
                //test.Print(" this is extension method");


                ////Khởi tạp colectin mới
                //List<string> listName = new List<string>() { "a", "b", "c" };
                //foreach (var item in listName)
                //{
                //     WriteLine(item);
                //}

                // WriteLine("calculator with optional para: " + calculator(10, 0, type: Calculate.Add));//skip default value

                //anonymous type
                //property read only
                var anonymousPerson = new { Name = "anonymous", Age = 999 };
                WriteLine("anonymousPerson " + anonymousPerson.Name + anonymousPerson.Age);
                Person person1 = new Person() { Name = "Test Anonymous1", Age = 20 };
                var anonymousPerson1 = new { Name = person1.Name, Age = person1.Age };//single name
                WriteLine("anonymousPerson1 " + anonymousPerson1.Name + anonymousPerson1.Age);
                Person person2 = new Person() { Name = "Test Anonymous2", Age = 20 };
                var anonymousPerson2 = new { person2.Name, person2.Age };//Access member
                WriteLine("anonymousPerson2 ");

                //anonymous vs linq
                var persons = new List<Person>()
                {
                    new Person(){Name="Name 1",Age=1},
                    new Person(){Name="Name 2",Age=2},
                    new Person(){Name="Name 3",Age=3},
                    new Person(){Name="Name 4",Age=4},
                    new Person(){Name="Name 5",Age=5},
                    new Person(){Name="Name 6",Age=6}
                };
                var anonymousPersons = persons.Select(person => new { person.Name });
                foreach (var item in anonymousPersons)
                {
                    WriteLine(item.Name);
                }


                //tupple

                var tupple = new Tuple<string, int>("Test Tuple ", 22);
                WriteLine("tuple: " + tupple.Item1 + tupple.Item2);

                //string

                var header = new string('+', 100);
                 WriteLine($"header: {header}");
                var list = new List<string>() { "a", "b", "c" };

                var result = string.Join(",", list);

                 WriteLine(result.Length);

                //call back

                 WriteLine(handleCalculate("Result: ", calculator));


                //Khi thự hiện call back để không phải nghĩa sẵn methob calculator như ở trên ta có thể sử dụng anonymous function như sau
                //chú ý: anonymous function cũng không sử dụng được optional function
                CalulatorDeligate anonymousFunction = delegate (int a, int b, int defaultValue, CalculateEnum type)
                {
                    switch (type)
                    {
                        case CalculateEnum.Add:
                            return a + b;
                        case CalculateEnum.Sub:
                            return a - b;
                        case CalculateEnum.Mul:
                            return a * b;
                        case CalculateEnum.Div:
                            return b == 0 ? defaultValue : a / b;
                    }
                    return defaultValue;
                };
                 WriteLine(handleCalculate("Result: ", anonymousFunction));

                //Lambda expression
                CalulatorDeligate lambdaExpression = (a, b, defaultValue, type) =>
                {
                    switch (type)
                    {
                        case CalculateEnum.Add:
                            return a + b;
                        case CalculateEnum.Sub:
                            return a - b;
                        case CalculateEnum.Mul:
                            return a * b;
                        case CalculateEnum.Div:
                            return b == 0 ? defaultValue : a / b;
                    }
                    return defaultValue;
                };
                 WriteLine(handleCalculate("Result: ", lambdaExpression));


                //Call back + Func + Lambda expression
                 WriteLine($"Call back + Func + Lambda expression length: {handleGetLength(text => text.Length)}");

                Predicate<Person> predicatePer = person => person.Age > 20;//khởi tạo 2 con trỏ hàm delegate và trỏ đến 1 anynymous function viết theo biểu thức lambda
                //Define 1 linQ

            }

        }
        //Delegate=>Có thể sử dụng optional parameter
        public delegate int CalulatorDeligate(int a, int b, int defaultValue = 0, CalculateEnum type = CalculateEnum.Add);
        
        //static int handleCalculate(string message, Func<int, int, int, CalculateEnum, int> calculator)
        static int handleCalculate(string message, CalulatorDeligate calculator)
        {

            int a = 5;//get từ request
            int b = 6;//get từ request

            // Func, Predicate ,Action => Không thể sử dụng optional parameter
            //int defaultValue = 0;
            //CalculateEnum type = CalculateEnum.Mul;//get từ request

             Write(message);
            //Func, Predicate ,Action=> Không thể sử dụng optional parameter
            //return calculator(a, b, defaultValue, type);
            //Delegate => Có sử dụng optional parameter
            return calculator(a, b);
        }

        /// <summary>
        /// Xử lý lấy length sử dụng kĩ thuật callback đến 1 delegate
        /// </summary>
        /// <param name="getLength"></param>
        /// <returns></returns>
        static int handleGetLength(Func<string, int> getLength)
        {
            string name = "Call back + Func + Lambda expression length";

            return getLength(name);
        }

        //optional para
        static int calculator(int a, int b, int defaultValue = 0, CalculateEnum type = CalculateEnum.Add)
        {
            switch (type)
            {
                case CalculateEnum.Add:
                    return a + b;
                case CalculateEnum.Sub:
                    return a - b;
                case CalculateEnum.Mul:
                    return a * b;
                case CalculateEnum.Div:
                    return b == 0 ? defaultValue : a / b;
            }
            return defaultValue;
        }
    }

    internal class Person : IDisposable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Dispose()
        {
            this.Name = null;
            this.Age = 0;
             WriteLine("dispose");
        }
    }


    //Extension Method
    static class PersionExtension
    {
        public static void Print(this Person person, string message)
        {
             WriteLine(person.Name + person.Age + message);
        }
    }
    enum CalculateEnum
    {
        Add, Sub, Mul, Div
    }



}
