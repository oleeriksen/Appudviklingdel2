using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiController]
[Route("word")]
public class WordController : ControllerBase
{
    private static readonly string[] AllWords = System.IO.File.ReadAllLines("Data/words.txt");

    [HttpGet]
    [Route("{n:int}")]
    public string[] Get(int n)
    {
        return AllWords.Take(n).ToArray();
    }
}



