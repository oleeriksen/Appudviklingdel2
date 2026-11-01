namespace Core.workshop;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<Clothing> Cloths { get; set; } = new();
}