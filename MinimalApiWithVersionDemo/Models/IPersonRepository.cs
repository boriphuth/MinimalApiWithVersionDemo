using System.Collections.Generic;

namespace MinimalApiWithVersionDemo.Models
{
    interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person person);
        void Remove(int id);
        bool Update(Person person);
    }
}