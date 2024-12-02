using TfdThreeTier.BuisnessLogic.DTOs;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface IGenericRepo<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<ServiceResponse> DeleteAsync(int id);
    Task<ServiceResponse> UpdateAsync(T entity);
}
