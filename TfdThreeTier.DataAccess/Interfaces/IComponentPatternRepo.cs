using System.Collections.Generic;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.DataAccess.Interfaces
{
    public interface IComponentPatternRepo
    {
        Task<ComponentPattern> CreateAsync(ComponentPattern entity);
        Task<ComponentPattern> GetByIdAsync(int componentId, int patternId);
        Task<List<ComponentPattern>> GetAllAsync();
        Task<ServiceResponse> DeleteAsync(int componentId, int patternId);
        Task<ServiceResponse> UpdateAsync(ComponentPattern entity);
        Task<List<ComponentPattern>> GetComponentPatternsByComponentIdAsync(int componentId);
    }
}

