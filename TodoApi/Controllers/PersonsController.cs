using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            return _context.GetAll();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public ActionResult<Person> GetById(long id)
        {
            var item = _context.GetById(id);

            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person item)
        {
            _context.AddPerson(item);
            //_context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(long id, TodoItem item)
        //{
        //    var todo = _context.TodoItems.Find(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    todo.IsComplete = item.IsComplete;
        //    todo.Name = item.Name;

        //    _context.TodoItems.Update(todo);
        //    _context.SaveChanges();
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    var todo = _context.TodoItems.Find(id);
        //    if (todo == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoItems.Remove(todo);
        //    _context.SaveChanges();
        //    return NoContent();
        //}
    }
}