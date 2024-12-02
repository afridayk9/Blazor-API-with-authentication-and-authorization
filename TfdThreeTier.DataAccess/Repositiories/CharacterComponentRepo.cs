using Microsoft.EntityFrameworkCore;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories;
public class CharacterComponentRepo : ICharacterComponentRepo
{
    private readonly ApplicationDbContext _dbContext;

    public CharacterComponentRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CharacterComponent> CreateAsync(CharacterComponent entity)
    {
        _dbContext.CharacterComponents.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<CharacterComponent> GetByIdAsync(int id)
    {
        return await _dbContext.CharacterComponents.FindAsync(id);
    }

    public async Task<List<CharacterComponent>> GetAllAsync()
    {
        return await _dbContext.CharacterComponents.ToListAsync();
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var entity = await _dbContext.CharacterComponents.FindAsync(id);
        if (entity == null)
        {
            return new ServiceResponse(false, "CharacterComponent not found.");
        }

        _dbContext.CharacterComponents.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "CharacterComponent deleted successfully.");
    }

    public async Task<ServiceResponse> UpdateAsync(CharacterComponent entity)
    {
        _dbContext.CharacterComponents.Update(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "CharacterComponent updated successfully.");
    }

    public async Task<List<CharacterComponent>> GetCharacterComponentsByCharacterIdAsync(int characterId)
    {
        return await _dbContext.CharacterComponents
            .Where(cc => cc.CharacterId == characterId)
            .ToListAsync();
    }
}








