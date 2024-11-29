using TfdThreeTier.BuisnessLogic.Entities;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface IMaterialRepo : IGenericRepo<Material>
{
    Task<List<Material>> GetMaterialsByComponentIdAsync(int componentId);
}
