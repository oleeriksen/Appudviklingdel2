namespace Backend.Repositories.WorkshopRepo;
using Core.workshop;

public interface IWorkshopRepo
{
    List<User> GetAllUsers();
    
    User GetUserById(int id);
    List<Clothing> GetAllClothing();
    
    Clothing GetClothingById(int userid, int clothinghid);

    void AddUser(User u);
    
    void AddClothToUser(int userid, Clothing clothing);
    
    void DeleteUserById(int id);
        

}