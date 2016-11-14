using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MinimalApiWithVersionDemo.Models;

namespace MinimalApiWithVersionDemo.Controllers
{
    public class PersonV2Controller : ApiController
    {
        static readonly IPersonV2Repository databasePlaceholder = new PersonV2Repository();

        public IEnumerable<PersonV2> GetAllPeople()
        {
            return databasePlaceholder.GetAll();
        }


        public PersonV2 GetPersonByID(int id)
        {
            PersonV2 person = databasePlaceholder.Get(id);
            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return person;
        }


        public HttpResponseMessage PostPerson(PersonV2 person)
        {
            person = databasePlaceholder.Add(person);
            var response = this.Request.CreateResponse<Person>(HttpStatusCode.Created, person);
            string uri = Url.Link("defaultVersioned", new { id = person.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        public bool PutPerson(PersonV2 person)
        {
            if (!databasePlaceholder.Update(person))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return true;
        }


        public void DeletePerson(int id)
        {
            PersonV2 person = databasePlaceholder.Get(id);
            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            databasePlaceholder.Remove(id);
        }
    }
}
