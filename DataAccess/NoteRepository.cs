using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal class NoteRepository(AppContext context) : INoteRepository
{
    private readonly AppContext _dbContext = context;
    public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
    {
        await context.Notes.AddAsync(note, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Notes.ToListAsync(cancellationToken);
    }

    public async Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Notes.FindAsync(id, cancellationToken);
    }
    public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
    {
        context.Notes.Update(note);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
    {
        context.Notes.Remove(note);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task ChangeCompleteAsync(Note note, CancellationToken cancellationToken = default)
    {
        context.Notes.Update(note);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task CreateMultipleAsync(List<Note> notes, CancellationToken cancellationToken = default)
    {
        foreach (var note in notes)
        {
            await CreateAsync(note, cancellationToken);
        }
    }
    
    public async Task DeleteAllAsync(CancellationToken cancellationToken = default)
    {
        var allNotes = await GetAllAsync(cancellationToken);
        foreach (var note in allNotes)
        {
            await DeleteAsync(note, cancellationToken);
        }
    }
    

}