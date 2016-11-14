using System;
using System.Collections.Generic;

namespace MinimalApiWithVersionDemo.Models
{
    public class PersonV2Repository : IPersonV2Repository
    {
        private List<PersonV2> _people = new List<PersonV2>();
        private int fakeDatabaseId = 1;

        public PersonV2Repository()
        {
            Add(new PersonV2 { LastName = "Lennon", FirstName = "John", DateOfBirth = Convert.ToDateTime("1985-6-14") });
            Add(new PersonV2 { LastName = "McCartney", FirstName = "Paul", DateOfBirth = Convert.ToDateTime("1995-11-5") });
            Add(new PersonV2 { LastName = "Harrison", FirstName = "George", DateOfBirth = Convert.ToDateTime("1991-7-12") });
            Add(new PersonV2 { LastName = "Starr", FirstName = "Ringo", DateOfBirth = Convert.ToDateTime("1970-8-15") });
        }

        public IEnumerable<PersonV2> GetAll()
        {
            return _people;
        }

        public PersonV2 Get(int id)
        {
            return _people.Find(p => p.Id == id);
        }

        public PersonV2 Add(PersonV2 person)
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

        public bool Update(PersonV2 person)
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