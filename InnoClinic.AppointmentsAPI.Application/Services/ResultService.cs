using AutoMapper;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Core.Exceptions;
using InnoClinic.AppointmentsAPI.Core.Exceptions.UserExceptions;

namespace InnoClinic.AppointmentsAPI.Application.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;

        public ResultService(IResultRepository resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }

        public async Task<ResultDTO> CreateResultAsync(ResultForCreationDTO result)
        {
            if (result == null)
            {
                throw new CustomNullReferenceException(typeof(ResultForCreationDTO));
            }

            var resultEntity = _mapper.Map<Result>(result);
            await _resultRepository.CreateResultAsync(resultEntity);

            return _mapper.Map<ResultDTO>(resultEntity);
        }

        public async Task DeleteResultAsync(Guid resultId)
        {
            var result = await _resultRepository.GetResultAsync(resultId);

            if (result == null)
            {
                throw new ResultNotFoundException(resultId);
            }

            await _resultRepository.DeleteResultAsync(result);
        }

        public async Task<IEnumerable<ResultDTO>> GetAllResultsAsync()
        {
            var resultsCollection = await _resultRepository.GetAllResultsAsync();

            return _mapper.Map<IEnumerable<ResultDTO>>(resultsCollection);
        }

        public async Task<ResultDTO> GetResultAsync(Guid resultId)
        {
            var result = await _resultRepository.GetResultAsync(resultId);

            if (result == null)
            {
                throw new ResultNotFoundException(resultId);
            }

            return _mapper.Map<ResultDTO>(result);
        }

        public async Task UpdateResultAsync(Guid resultId, ResultForUpdateDTO result)
        {
            if (result == null)
            {
                throw new CustomNullReferenceException(typeof(ResultForUpdateDTO));
            }

            var resultEntity = await _resultRepository.GetResultAsync(resultId, trackChanges: true);

            if (resultEntity == null)
            {
                throw new ResultNotFoundException(resultId);
            }

            _mapper.Map(result, resultEntity);

            await _resultRepository.SaveAsync();
        }
    }
}
