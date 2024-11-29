using TfdThreeTier.BuisnessLogic.DTOs;

namespace TfdThreeTier.Client.Interfaces;

public interface IGenericService<T> where T : class
{
    Task<ServiceResponse> CreateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<ServiceResponse> DeleteAsync(int id);
    Task<ServiceResponse> UpdateAsync(T entity);
}
