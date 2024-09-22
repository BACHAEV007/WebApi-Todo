using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal class NoteRepository(AppContext context) : INoteRepository
{
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
}