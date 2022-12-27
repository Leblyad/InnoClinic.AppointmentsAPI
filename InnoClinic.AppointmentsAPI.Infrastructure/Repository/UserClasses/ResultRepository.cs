using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.AppointmentsAPI.Infrastructure.Repository.UserClasses
{
    public class ResultRepository : RepositoryBase<Result>, IResultRepository
    {
        public ResultRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateResultAsync(Result result)
        {
            Create(result);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteResultAsync(Result result)
        {
            Delete(result);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Result>> GetAllResultsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task<Result> GetResultAsync(Guid resultId, bool trackChanges = false) =>
            await FindByCondition(result => result.Id.Equals(resultId), trackChanges)
                .SingleOrDefaultAsync();

        public Task SaveAsync() => RepositoryContext.SaveChangesAsync();
    }
}
