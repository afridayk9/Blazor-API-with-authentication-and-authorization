using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories;
public class CharacterRepo : ICharacterRepo
{
    private readonly ApplicationDbContext _dbContext;

    public CharacterRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse> CreateAsync(Character entity)
    {
        var check = await _dbContext.Characters.FirstOrDefaultAsync(c => c.Name == entity.Name);
        if (check != null)
            return new ServiceResponse(false, "Character already exists.");

        _dbContext.Characters.Add(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Character created successfully.");
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var character = await _dbContext.Characters.FindAsync(id);
        if (character == null)
            return new ServiceResponse(false, "Character not found.");

        _dbContext.Characters.Remove(character);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Character deleted successfully.");
    }

    public async Task<List<Character>> GetAllAsync()
    {
        return await _dbContext.Characters.ToListAsync();
    }

    public async Task<Character> GetByIdAsync(int id)
    {
        return await _dbContext.Characters.FindAsync(id);
    }

    public async Task<ServiceResponse> UpdateAsync(Character entity)
    {
        var character = await _dbContext.Characters.FindAsync(entity.Id);
        if (character == null)
            return new ServiceResponse(false, "Character not found.");

        character.Name = entity.Name;

        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Character updated successfully.");
    }
}
