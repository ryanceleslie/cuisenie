using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IApiClient<T>
    {
        Task<T> Get(T entity);
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<T> Patch(T entity);
        Task<T> Delete(T entity);
    }
}