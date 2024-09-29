using DataAccess;

namespace BusinnesLogic;

public interface INoteService
{
    Task <Note> CreateAsync(NoteDto noteDto, CancellationToken cancellationToken = default);
    Task <List<Note>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, NoteTextDto noteDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task ChangeCompleteAsync(int id, CancellationToken cancellationToken = default);
    Task CreateMultipleAsync(List<NoteDto> noteDtos, CancellationToken cancellationToken = default);
    Task DownloadTasksAsync(List<NoteDto> noteDtos, CancellationToken cancellationToken = default);
}