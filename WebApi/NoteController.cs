using BusinnesLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("Task")]
public class NoteController(INoteService noteService) : ControllerBase
{
    [HttpPost("CreateTask")]
    public async Task<IActionResult> CreateAsync([FromBody] NoteDto noteDto)
    {
        Note createNote = await noteService.CreateAsync(noteDto);
        return Ok(createNote);
    }

    [HttpGet("GetTasks")]
    public async Task<IActionResult> GetAllAsync()
    {
        var notes = await noteService.GetAllAsync();
        return Ok(notes);
    }

    [HttpPut("UpdateTask/{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] NoteTextDto noteTextDto)
    {
        await noteService.UpdateAsync(id, noteTextDto);
        return Ok();
    }

    [HttpDelete("DeleteTask/{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await noteService.DeleteAsync(id);
        return NoContent();
    }

    [HttpPut("CompleteTask/{id:int}")]
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