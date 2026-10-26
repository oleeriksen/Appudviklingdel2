using Core;

namespace Backend.Repositories.TodoRepo;

public class TodoRepositoryInMemory : ITodoRepository
{
    private List<TodoItem> _todoItems = new();
    
    public TodoItem[] GetAll()
    {
        return _todoItems.ToArray();
    }

    public void Add(TodoItem item)
    {
        item.Id = Random.Shared.Next(); // unique - we hope so... FIXME
        _todoItems.Add(item);
    }

    public void DeleteById(int id)
    {
        _todoItems.RemoveAll(x => x.Id == id);
    }

    public void Toggle(TodoItem item)
    {
       TodoItem theItem =  _todoItems.First(x => x.Id == item.Id);
       theItem.IsDone = !theItem.IsDone;
    }
}