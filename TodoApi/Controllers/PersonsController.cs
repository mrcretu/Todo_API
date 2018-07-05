using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonList _context;

        public PersonsController()
        {
            _context = PersonList.Products;
        }

        [HttpGet(Name ="GetAll")]
        public ActionResult<List<Person>> GetAll()
        {
            return _context.GetAll(); //call GetAll() method from PersonList
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public ActionResult<Person> GetById(long id)
        {
            var item = _context.GetById(id); //call GetById() method from PersonList

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person item)
        {
            _context.AddPerson(item); //call AddPerson() method from PersonList
            return CreatedAtRoute("GetPerson", new { id = item.Id }, item); // return a route to the new person added
        }

        [HttpPut]
        public IActionResult Update(Person item)
        {
            if (_context.UpdatePerson(item)) //call UpdatePerson() method from PersonList
                return CreatedAtRoute("GetPerson", new { id = item.Id }, item); // return a route to the new person updated info 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Person>> Delete(long id)
        {
            if (_context.RemovePerson(id)) //call RemovePerson() method from the PersonList
                return _context.GetAll(); // return the persons which remained in the list
            return NotFound();
        }
    }
}