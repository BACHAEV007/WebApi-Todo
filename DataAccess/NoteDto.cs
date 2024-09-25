using System.ComponentModel;

namespace DataAccess;

public class NoteDto
{
    public int Id { get; set; }
    
    [DefaultValue("")]
    public string Text { get; set; } = string.Empty;

    [DefaultValue(false)]
    public bool Check { get; set; } = false;
}