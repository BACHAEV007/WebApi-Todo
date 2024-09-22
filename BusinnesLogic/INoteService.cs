using DataAccess;

namespace BusinnesLogic;

public interface INoteService
{
    Task CreateAsync(string text, CancellationToken cancellationToken = default);
    Task <List<Note>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default);
}