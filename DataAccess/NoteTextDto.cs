namespace DataAccess;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class NoteTextDto
{
    [DefaultValue("")]
    [Required]
    public string Text { get; set; } = string.Empty;
}