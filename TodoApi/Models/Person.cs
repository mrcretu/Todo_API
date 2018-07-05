
using System;

namespace TodoApi.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
