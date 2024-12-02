using System.Collections.Generic;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.DataAccess.Interfaces
{
    public interface IMaterialPatternRepo
    {
        Task<MaterialPattern> CreateAsync(MaterialPattern entity);
        Task<MaterialPattern> GetByIdAsync(int id);
        Task<List<MaterialPattern>> GetAllAsync();
        Task<ServiceResponse> DeleteAsync(int id);
        Task<ServiceResponse> UpdateAsync(MaterialPattern entity);
        Task<List<MaterialPattern>> GetMaterialPatternsByMaterialIdAsync(int materialId);
    }
}

