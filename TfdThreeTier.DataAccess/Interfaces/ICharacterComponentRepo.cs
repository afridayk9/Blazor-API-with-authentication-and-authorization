using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface ICharacterComponentRepo 
{
    Task<CharacterComponent> CreateAsync(CharacterComponent entity);
    Task<CharacterComponent> GetByIdAsync(int id);
    Task<List<CharacterComponent>> GetAllAsync();
    Task<ServiceResponse> DeleteAsync(int id);
    Task<ServiceResponse> UpdateAsync(CharacterComponent entity);
    Task<List<CharacterComponent>> GetCharacterComponentsByCharacterIdAsync(int characterId);
}