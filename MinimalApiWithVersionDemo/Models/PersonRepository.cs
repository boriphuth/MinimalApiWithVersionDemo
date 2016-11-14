using System;
using System.Collections.Generic;

namespace MinimalApiWithVersionDemo.Models
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _people = new List<Person>();
        private int fakeDatabaseId = 1;

        public PersonRepository()
        {
            Add(new Person { LastName = "Lennon", FirstName = "John" });
            Add(new Person { LastName = "McCartney", FirstName = "Paul" });
            Add(new Person { LastName = "Harrison", FirstName = "George" });
            Add(new Person { LastName = "Starr", FirstName = "Ringo" });
        }

        public IEnumerable<Person> GetAll()
        {
            return _people;
        }

        public Person Get(int id)
        {
            return _people.Find(p => p.Id == id);
        }

        public Person Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            person.Id = fakeDatabaseId++;
            _people.Add(person);
            return person;
        }

        public void Remove(int id)
        {
            _people.RemoveAll(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }
            int index = _people.FindIndex(p => p.Id == person.Id);
            if (index == -1)
            {
                return false;
            }
            _people.RemoveAt(index);
            _people.Add(person);
            return true;
        }
    }

}