
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;

namespace InnoClinic.AppointmentsAPI.Application.Services.Abstractions
{
    public interface IResultService
    {
        Task<IEnumerable<ResultDTO>> GetAllResultsAsync();
        Task<ResultDTO> GetResultAsync(Guid resultId);
        Task<ResultDTO> CreateResultAsync(ResultForCreationDTO result);
        Task UpdateResultAsync(Guid resultId, ResultForUpdateDTO result);
        Task DeleteResultAsync(Guid resultId);
    }
}
