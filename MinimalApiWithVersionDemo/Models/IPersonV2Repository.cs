using System.Collections.Generic;

namespace MinimalApiWithVersionDemo.Models
{
    interface IPersonV2Repository
    {
        IEnumerable<PersonV2> GetAll();
        PersonV2 Get(int id);
        PersonV2 Add(PersonV2 person);
        void Remove(int id);
        bool Update(PersonV2 person);
    }
}