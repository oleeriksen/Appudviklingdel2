namespace BlazorApp1.Service;

using BlazorApp1.Logic;


public class LoginService
{
    private List<User> mUsers;
    
    public LoginService()
    {
        mUsers = [new User { Name = "rip", Password = "1234", Role = "admin" },
            new User { Name = "rap", Password = "2345", Role="Normal"},
            new User { Name="rup", Password = "3456", Role="admin"}];
    }

    public User? ValidLogin(string name, string password)
    {
        foreach (User u in mUsers)
            if (u.Name == name && u.Password == password)
            {
                User userInfo = new User { Name = u.Name, Role = u.Role, Password = "verified" };
                return userInfo;
            }

        return null;
    }

}