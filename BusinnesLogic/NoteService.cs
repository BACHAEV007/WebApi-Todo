using DataAccess;

namespace BusinnesLogic;

internal class NoteService(INoteRepository noteRepository) : INoteService
{
    public async Task<Note> CreateAsync(NoteDto noteDto, CancellationToken cancellationToken = default)
    {
        var note = new Note
        {
            Text = noteDto.Text ?? string.Empty,
            Check = noteDto.Check
        };
        await noteRepository.CreateAsync(note, cancellationToken);
        return note;
    }

    public async Task<List<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var notes = await noteRepository.GetAllAsync(cancellationToken);
        if (notes is null)
        {
            throw new Exception("No notes found");
        }

        return notes;
    }

    public async Task UpdateAsync(int id, NoteTextDto noteDto, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
        {
            throw new Exception("No note found");
        }
        note.Text = noteDto.Text ?? string.Empty;
        await noteRepository.UpdateAsync(note, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
        {
            throw new Exception($"No notes found");
        }
        await noteRepository.DeleteAsync(note, cancellationToken);
    }

    public async Task ChangeCompleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
        {
            throw new Exception($"No notes found");
        }

        note.Check = !note.Check;
        await noteRepository.ChangeCompleteAsync(note, cancellationToken);
    }
    public async Task CreateMultipleAsync(List<NoteDto> noteDtos, CancellationToken cancellationToken = default)
    {
        var notes = noteDtos.Select(noteDto => new Note
        {
            Text = noteDto.Text ?? string.Empty,
            Check = noteDto.Check
        }).ToList();

        await noteRepository.CreateMultipleAsync(notes, cancellationToken);
    }
    
    public async Task DownloadTasksAsync(List<NoteDto> noteDtos, CancellationToken cancellationToken = default)
    {
        await noteRepository.DeleteAllAsync(cancellationToken);
        var notes = noteDtos.Select(noteDto => new Note
        {
            Text = noteDto.Text ?? string.Empty,
            Check = noteDto.Check
        }).ToList();

        await noteRepository.CreateMultipleAsync(notes, cancellationToken);
    }
}