namespace DataAccess;

public interface INoteRepository
{
    Task CreateAsync(Note note, CancellationToken cancellationToken = default);
    Task <List<Note>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
    Task <Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
    Task ChangeCompleteAsync(Note note, CancellationToken cancellationToken = default);
    Task CreateMultipleAsync(List<Note> notes, CancellationToken cancellationToken = default); 
    Task DeleteAllAsync(CancellationToken cancellationToken = default);
}