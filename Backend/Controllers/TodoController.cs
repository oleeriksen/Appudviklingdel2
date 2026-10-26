using Microsoft.AspNetCore.Mvc;
using Backend.Repositories.TodoRepo;
using Core;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private ITodoRepository _repo;

        public TodoController(ITodoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public TodoItem[] Get()
        {
            return _repo.GetAll();
        }

        [HttpPost]
        public void Add(TodoItem item) {
            _repo.Add(item);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void Delete(int id)
        {
            _repo.DeleteById(id);
        }
        
        [HttpPut]
        public void Toggle(TodoItem item) {
            _repo.Toggle(item);
        }
        
    }
}