using DataAccess;

namespace BusinnesLogic;

public interface INoteService
{
    Task CreateAsync(NoteDto noteDto, CancellationToken cancellationToken = default);
    Task <List<NoteDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task UpdateAsync(NoteDto noteDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task ChangeCompleteAsync(int id, CancellationToken cancellationToken = default);
    Task CreateMultipleAsync(List<NoteDto> noteDtos, CancellationToken cancellationToken = default);
    Task DownloadTasksAsync(List<NoteDto> noteDtos, CancellationToken cancellationToken = default);
}