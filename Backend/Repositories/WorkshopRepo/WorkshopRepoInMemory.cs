using Core.workshop;

namespace Backend.Repositories.WorkshopRepo;

public class WorkshopRepoInMemory : IWorkshopRepo
{
    private List<User> _users;

    public WorkshopRepoInMemory()
    {
        _users = new()
        {
            new()
            {
                Id = 1,
                Name = "Alice",
                Cloths = new()
                {
                    new() { Id = 1, Title = "Bukser", Brand = "Levis", Color = "black", Owner = 1 },
                    new() { Id = 2, Title = "Trøje", Brand = "Best", Color = "white", Owner = 1 }
                }
            },
            new()
            {
                Id = 2,
                Name = "Bente",
                Cloths = new()
                {
                    new() { Id = 1, Title = "Jakke", Brand = "JJ", Color = "green", Owner = 2 },
                    new() { Id = 2, Title = "dansesko", Brand = "Ecco", Color = "red", Owner = 2 }
                }
            }
        };
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User GetUserById(int id)
    {
        return _users.First(u => u.Id == id);
    }

    public List<Clothing> GetAllClothing()
    {
        List<Clothing> result = new();
        foreach (User u in _users)
            result.AddRange(u.Cloths);
        return result;
    }

    public Clothing GetClothingById(int userid, int clothinghid)
    {
        return GetUserById(userid).Cloths.First(c => c.Id == clothinghid);
    }

    public void AddUser(User u)
    {
        u.Id = Random.Shared.Next();
        _users.Add(u);
    }

    public void AddClothToUser(int userid, Clothing clothing)
    {
        clothing.Id = Random.Shared.Next();
        clothing.Owner = userid;
        GetUserById(userid).Cloths.Add(clothing);
    }

    public void DeleteUserById(int id)
    {
        _users.RemoveAll(u => u.Id == id);
    }
}