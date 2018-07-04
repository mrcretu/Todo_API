using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(int id, string name, string surname, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
    }
}
