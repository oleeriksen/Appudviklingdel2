namespace Core.workshop;

public class Clothing
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public int Owner { get; set; }
}