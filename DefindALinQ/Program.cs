using System;
using System.Collections.Generic;

namespace DefindALinQ
{

    public static class MyLinQ
    {
        public static IEnumerable<Tsource> MyWhere<Tsource>(this IEnumerable<Tsource> sources, Func<Tsource, int, bool> func, int minAge)
        {
            if (sources != null)
            {
                foreach (var item in sources)
                {
                    if (func(item, minAge))
                    {
                        yield return item;
                    }
                }
            }

        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool isOld { get => Age > 20; }
        public override string ToString() => $"Name: {Name}, Age: {Age}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>() { new Student() { Name = "Student 1", Age = 18 },
            new Student() { Name = "Student 1", Age = 19 },
            new Student() { Name = "Student 1", Age = 20 },
            new Student() { Name = "Student 1", Age = 31 },
            new Student() { Name = "Student 1", Age = 40 }};
            var result = students.MyWhere((stu, minAge) => stu.Age > minAge, 20);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
