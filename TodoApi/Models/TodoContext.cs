using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public sealed class PersonList
    {
        private static PersonList instance = null;
        private static List<Person> persons;
        private static readonly object padlock = new object();
        

        private PersonList()
        {
            persons = new List<Person>();
            Seed();

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

        private void Seed()
        {
            persons.Add(new Person(1, "Cretu", "Marius", 21));
            persons.Add(new Person(2, "Borceanu","Florin",20));
            persons.Add(new Person(3, "Marza","Bogdan", 20));
        }


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
                var p_id = person.Id;
                persons.Add(person);
            return true;
        }
        public bool UpdatePerson(Person person)
        {
            GetById(person.Id).Name = person.Name;
            GetById(person.Id).Surname = person.Surname;
            GetById(person.Id).Age = person.Age;
            return true;
        }

        public bool RemovePerson(long person_id)
        {
            Console.WriteLine(person_id);
            var count = 0;
            foreach(var it in persons)
            {
                if(it.Id == person_id)
                {
                    persons.RemoveAt(count);
                    return true;
                }
                count++;
            }
            return false;
        }
    }

}