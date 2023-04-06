using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly List<TodoItem> _todoItems = new List<TodoItem>();

        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _todoItems;
        }

        [HttpGet("{id}")]
        public TodoItem GetById(int id)
        {
            return _todoItems.Find(item => item.Id == id);
        }

        [HttpPost]
        public TodoItem Create(TodoItem item)
        {
            _todoItems.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public TodoItem Update(int id, TodoItem item)
        {
            var index = _todoItems.FindIndex(existingItem => existingItem.Id == id);
            _todoItems[index] = item;
            return item;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _todoItems.Find(existingItem => existingItem.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            _todoItems.Remove(item);
            return NoContent();
        }
    }
}
