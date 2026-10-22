using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{

    [HttpGet]
    public String Get()
    {
        return "backend server - version 1.0 - 22/10-2026";
    }
    
}