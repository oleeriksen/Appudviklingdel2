using Microsoft.AspNetCore.Mvc;


namespace Backend.Controllers;

[ApiController]
[Route("api/word")]
public class WordController : ControllerBase
{

    private static string[] allWords = System.IO.File.ReadAllLines("Data/words.txt");
    
    [HttpGet]
    [Route("first/{n:int}")]
    public string[] GetFirst(int n)
    {
        return allWords.Take(n).ToArray();
    }
    
    [HttpGet]
    [Route("startswith/{searchword}")]
    public string[] GetStartswith(string searchword)
    {
        List<string> matches = new List<string>(); // list is easier to work with than array
        
        foreach (string word in allWords)
        {
            if (word.StartsWith(searchword, StringComparison.OrdinalIgnoreCase)) // ignore case
            {
                matches.Add(word);
            }
        }
        return matches.ToArray();
    }
    
    [HttpGet]
    [Route("contains/{searchword}")]
    public string[] GetContains(string searchword)
    {
        List<string> matches = new List<string>(); // list is easier to work with than array
        
        foreach (string word in allWords)
        {
            if (word.Contains(searchword, StringComparison.OrdinalIgnoreCase)) // ignore case
            {
                matches.Add(word);
            }
        }
        return matches.ToArray();
    }
    
    [HttpGet]
    [Route("distance1/{searchword}")]
    public string[] GetDistance1(string searchword)
    {
        List<string> matches = new List<string>();

        foreach (string word in allWords)
        {
            if (word.Length == searchword.Length)
            {
                int distance = 0;

                for (int i = 0; i < searchword.Length; i++)
                {
                    if (char.ToLower(word[i]) != char.ToLower(searchword[i]))
                    {
                        distance++;
                    }
                }

                if (distance <= 1)
                {
                    matches.Add(word);
                }
            }
        }
        return matches.ToArray();
    }
    
}