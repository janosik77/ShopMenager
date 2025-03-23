using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopMenager.Services.ApiService
{
    public interface IApiService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }
}
