using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<T> GetSingleBySpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> List(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAll();
        Task<int> Count(ISpecification<T> spec);
    }
}