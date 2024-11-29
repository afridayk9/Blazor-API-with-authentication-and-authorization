
using TfdThreeTier.BuisnessLogic.Entities;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface IPatternRepo : IGenericRepo<Pattern>
{
    Task<List<Pattern>> GetPatternsByMaterialIdAsync(int materialId);
    Task<List<Pattern>> GetPatternsByComponentIdAsync(int componentId);
    Task<List<Pattern>> GetPatternsByCharacterIdAsync(int characterId);
}
