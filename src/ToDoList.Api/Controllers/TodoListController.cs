using ToDoList.Api.Models;
using ToDoList.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ToDoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ToDoListService _toDoListService;

        public TodoListController(ToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        public ActionResult<List<TodoList>> Get() =>
            _toDoListService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTodoList")]
        public ActionResult<List<TodoList>> Get(string id)
        {
            var todoList = _toDoListService.Get(id);

            if(todoList == null)
                return NotFound();
            
            return todoList;
        }

        [HttpPost]
        public ActionResult<TodoList> Create(TodoList todoList)
        {
            _toDoListService.Create(todoList);

            return CreatedAtRoute("GetTodoList", new { id = todoList.Id.ToString()}, todoList);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, TodoList todoListIn)
        {
            var todoList = _toDoListService.Get(id);

            if(todoList == null)
                return NotFound();

            _toDoListService.Update(id, todoListIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var todoList = _toDoListService.Get(id);

            if(todoList == null)
                return NotFound();

            _toDoListService.Remove(id);

            return NoContent();
        }
    }
}