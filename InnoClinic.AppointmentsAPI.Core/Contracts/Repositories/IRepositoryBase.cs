using System.Linq.Expressions;

namespace InnoClinic.AppointmentsAPI.Core.Contracts.Repositories
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        IQueryable<T> FindAll(bool trackChanges);
    }
}
