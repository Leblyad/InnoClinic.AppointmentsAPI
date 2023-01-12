using InnoClinic.AppointmentsAPI.Core.Entitites.Models;

namespace InnoClinic.AppointmentsAPI.Core.Contracts.Repositories
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> GetAllResultsAsync(bool trackChanges = false);
        Task<Result> GetResultAsync(Guid resultId, bool trackChanges = false);
        Task CreateResultAsync(Result result);
        Task DeleteResultAsync(Result result);
        Task SaveAsync();
    }
}
