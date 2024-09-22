namespace DataAccess;

public interface INoteRepository
{
    Task CreateAsync(Note note, CancellationToken cancellationToken = default);
    Task <List<Note>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
    Task <Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}