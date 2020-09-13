using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static List<Person> people = new List<Person>
        {
            new Person {Id =1, Name = "Sabina", Surname = "Aitbayeva"},
            new Person {Id =2, Name = "Aruzhan", Surname = "Amirkhan"}
        };

        [Route("People")]
        public IEnumerable<Person> Get()
        {
            return people;
        }

        [Route("person/{id:int}", Name = "PersonById")]
        public Person GetById(int id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);
            if (person == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return person;
        }

        [Route("person")]
        public IHttpActionResult Post(Person p)
        {
            people.Add(p);
            return CreatedAtRoute("PersonById", new {id = p.Id}, p);
        }
    }
}
