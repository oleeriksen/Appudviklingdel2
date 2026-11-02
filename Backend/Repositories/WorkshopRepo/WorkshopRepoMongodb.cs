using Core;
using Core.workshop;
using MongoDB.Driver;

namespace Backend.Repositories.WorkshopRepo;

public class WorkshopRepoMongodb: IWorkshopRepo
{
    private IMongoCollection<User> _userCollection;

    public WorkshopRepoMongodb()
    {
        // atlas database
        //var password = ""; //add
        //var mongoUri = $"mongodb+srv://olee58:{password}@cluster0.olmnqak.mongodb.net/?retryWrites=true&w=majority";
           
        //local mongodb
        var mongoUri = "mongodb://localhost:27017/";
            
        MongoClient client;
        try
        {
            client = new MongoClient(mongoUri);
        }
        catch (Exception e)
        {
            Console.WriteLine("There was a problem connecting to your " +
                              "Atlas cluster. Check that the URI includes a valid " +
                              "username and password, and that your IP address is " +
                              $"in the Access List. Message: {e.Message}");
            throw; }

        // Provide the name of the database and collection you want to use.
        var dbName = "workshop";
        var collectionName = "user";

        _userCollection = client.GetDatabase(dbName)
            .GetCollection<User>(collectionName);
    }

    public List<User> GetAllUsers()
    {
        var noFilter = Builders<User>.Filter.Empty;
        return _userCollection.Find(noFilter).ToList();
    }

    public User GetUserById(int id)
    {
        var idFilter = Builders<User>.Filter.Where(u => u.Id == id);
        return _userCollection.Find(idFilter).First();
    }

    public List<Clothing> GetAllClothing()
    {
        List<Clothing> result = new();
        foreach (User u in GetAllUsers())
            result.AddRange(u.Clothings);
        return result;
    }

    public Clothing GetClothingById(int userid, int clothinghid)
    {
        return GetUserById(userid).Clothings.First(c => c.Id == clothinghid);
    }

    public void AddUser(User u)
    {
        u.Id = Random.Shared.Next(); // just a random integer
        _userCollection.InsertOne(u);
    }

    public void AddClothToUser(int userid, Clothing clothing)
    {
        clothing.Id = Random.Shared.Next();
        clothing.Owner = userid;
        User u = GetUserById(userid);
        u.Clothings.Add(clothing);
        var tmp = u.Clothings;
        // opdater
        var updateDef = Builders<User>.Update
            .Set(x => x.Clothings, tmp);
        _userCollection.UpdateOne(aUser => aUser.Id == userid, updateDef);
    }

    public void DeleteUserById(int id)
    {
        throw new NotImplementedException();
    }
}