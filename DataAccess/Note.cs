
namespace DataAccess;

public class Note
{
    public int Id { get; set; }
    
    public required string Text { get; set; }
    public bool Check { get; set; } = false;
}