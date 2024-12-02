using System.Collections.Generic;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.DataAccess.Interfaces
{
    public interface IComponentPatternRepo
    {
        Task<ComponentPattern> CreateAsync(ComponentPattern entity);
        Task<ComponentPattern> GetByIdAsync(int id);
        Task<List<ComponentPattern>> GetAllAsync();
        Task<ServiceResponse> DeleteAsync(int id);
        Task<ServiceResponse> UpdateAsync(ComponentPattern entity);
        Task<List<ComponentPattern>> GetComponentPatternsByComponentIdAsync(int componentId);
    }
}

