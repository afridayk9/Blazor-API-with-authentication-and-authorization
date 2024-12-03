using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.BuisnessLogic.DTOs;

namespace TfdThreeTier.DataAccess.Interfaces
{
    public interface ICharacterPatternRepo
    {
        Task<CharacterPattern> CreateAsync(CharacterPattern entity);
        Task<CharacterPattern> GetByIdAsync(int characterId, int patternId);
        Task<List<CharacterPattern>> GetAllAsync();
        Task<ServiceResponse> DeleteAsync(int characterId, int patternId);
        Task<ServiceResponse> UpdateAsync(CharacterPattern entity);
        Task<List<CharacterPattern>> GetCharacterPatternsByCharacterIdAsync(int characterId);
    }
}


