using System;
using System.Collections.Generic;
using System.IO;

namespace EnumableAndYield
{

    class Person
    {
        public string Name { get; set; }
        public int age { get; set; }
        public override string ToString()
        {
            return $"{Name} {age}";
        }
    }



    class Program
    {
        static Person convertStringToPerson(string personString)
        {
            Person person = new Person();
            string[] words = personString.Split(" ");
            person.Name = words[0];
            person.age = Int16.Parse(words[1]);
            return person;
        }

        static List<Person> readPeopleFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<Person> people = new List<Person>();
            foreach (var line in lines)
            {

                Person person = convertStringToPerson(line);
                Console.WriteLine("complete get a person");
                people.Add(person);
            }
            return people;
        }
        static IEnumerable<Person> readPeopleFromFileIEnum(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<Person> people = new List<Person>();
            foreach (var line in lines)
            {

                Person person = convertStringToPerson(line);
                Console.WriteLine("complete get a person");
                yield return person;
            }
        }
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>() { new Person { Name = "Name1", age = 1 }, new Person { Name = "Name2", age = 2 } };
            using (var tw = new StreamWriter("person.txt"))
            {
                foreach (var person in people)
                {
                    tw.WriteLine(person.ToString());
                }
            }
            //Đọc dữ liệu từ file bình thường

            List<Person> peopleRead = readPeopleFromFile("person.txt");
            foreach (var item in peopleRead)
            {
                Console.WriteLine(item);
            }

            IEnumerable<Person> peopleReadIEnum = readPeopleFromFileIEnum("person.txt");
            foreach(var item in peopleReadIEnum)
            {
                Console.WriteLine(item);
            }
        }
    }
}
