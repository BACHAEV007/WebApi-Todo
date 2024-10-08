using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess;

public class NoteDto
{
    [DefaultValue("")]
    [Required]
    public string Text { get; set; } = string.Empty;

    [DefaultValue(false)]
    public bool Check { get; set; }
}