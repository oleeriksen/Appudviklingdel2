using Backend.Repositories.WorkshopRepo;
using Core.workshop;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.workshop;

[ApiController]
[Route("api/workshop")]
public class UserController : ControllerBase
{
    private IWorkshopRepo _repo;

    public UserController(IWorkshopRepo repo) {
        this._repo = repo;
    }

    [HttpGet]
    [Route("allusers")]
    public List<User> GetAllUers()
    {
        return _repo.GetAllUsers();
    }

    [HttpGet]
    [Route("allclothings")]
    public List<Clothing> GetAllClothings()
    {
        return _repo.GetAllClothing();
    }

    [HttpPost]
    [Route("adduser")]
    public void AddUser(User u) {
        _repo.AddUser(u);
    }
    
    [HttpPost]
    [Route("addcloth/{userid:int}")]
    public void AddClothToUser(int userid, [FromBody] Clothing clothing) {
        _repo.AddClothToUser(userid, clothing);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public void DeletebyId(int id)
    {
    }
    
}