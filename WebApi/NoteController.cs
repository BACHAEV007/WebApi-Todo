using BusinnesLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("Note")]
public class NoteController(INoteService noteService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] NoteDto noteDto)
    {
        await noteService.CreateAsync(noteDto);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var notes = await noteService.GetAllAsync();
        return Ok(notes);
    }

    [HttpPut("UpdateTask")]
    public async Task<IActionResult> UpdateAsync([FromBody] NoteDto noteDto)
    {
        await noteService.UpdateAsync(noteDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await noteService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("complete/{id:int}")]
    public async Task<IActionResult> ChangeCompleteAsync(int id)
    {
        await noteService.ChangeCompleteAsync(id);
        return NoContent();
    }
    
    [HttpPost("CreateMultiply")]
    public async Task<IActionResult> CreateMultipleNotes([FromBody] List<NoteDto> noteDtos)
    {
        await noteService.CreateMultipleAsync(noteDtos);
        return Ok();
    }
    [HttpPost("DownloadNotes")]
    public async Task<IActionResult> DownloadNotes([FromBody] List<NoteDto> noteDtos)
    {
        await noteService.DownloadTasksAsync(noteDtos);
        return Ok();
    }
}