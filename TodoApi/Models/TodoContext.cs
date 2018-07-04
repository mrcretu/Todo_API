using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public sealed class PersonList
    {
        private static PersonList instance = null;
        private static readonly object padlock = new object();

        private PersonList()
        {
            Seed();
        }

        private void Seed()
        {
            persons.Add(new Person(1, "Cretu", "Marius", 21));
            persons.Add(new Person(2, "Borceanu","Florin",20));
            persons.Add(new Person(3, "Marza","Bogdan", 20));
        }

        public static PersonList Products
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PersonList();
                    }

                    return instance;
                }
            }
        }
        private static List<Person> persons = new List<Person>();

        public List<Person> GetAll()
        {
            return persons;
        }

        public Person GetById(long id)
        { 
            foreach (var person in persons)
            {
                if (person.Id == id) return person;
                }
        return null;
        }

        public bool AddPerson(Person person)
        {
            if (person == null) return false;
            else
            {
                var p_id = person.Id;
                persons.Add(person);
            }
            if (GetById(person.Id) != null) return true;
            return false;
        }
    }
}