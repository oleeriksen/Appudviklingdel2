using Core;

namespace Backend.Repositories.TodoRepo;

public interface ITodoRepository
{
    TodoItem[] GetAll();
    void Add(TodoItem item);
    void DeleteById(int id);
    void Toggle(TodoItem item);
}