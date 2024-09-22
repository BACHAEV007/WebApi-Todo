using BusinnesLogic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

[ApiController]
[Route("Note")]
public class NoteController(INoteService noteService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(string text)
    {
        await noteService.CreateAsync(text);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await noteService.GetAllAsync();
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, string newText)
    {
        await noteService.UpdateAsync(id, newText);
        return NoContent();
    }
}