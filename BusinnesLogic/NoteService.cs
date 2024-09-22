using DataAccess;

namespace BusinnesLogic;

internal class NoteService(INoteRepository noteRepository) : INoteService
{
    public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
    {
        var note = new Note
        {
            Text = text
        };
        await noteRepository.CreateAsync(note, cancellationToken);
    }

    public async Task<List<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var notes = await noteRepository.GetAllAsync(cancellationToken);
        if (notes is null)
        {
            throw new Exception($"No notes found");
        }
        return notes;
    }

    public async Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
        {
            throw new Exception($"No notes found");
        }
        note.Text = newText;
        await noteRepository.UpdateAsync(note, cancellationToken);
    }
}