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
public class ComponentRepo : IComponentRepo
{
    private readonly ApplicationDbContext _dbContext;

    public ComponentRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Component> CreateAsync(Component entity)
    {
        var check = await _dbContext.Components.FirstOrDefaultAsync(c => c.Name == entity.Name);
        if (check != null)
            return entity;

        _dbContext.Components.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var component = await _dbContext.Components.FindAsync(id);
        if (component == null)
            return new ServiceResponse(false, "Component not found.");

        _dbContext.Components.Remove(component);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Component deleted successfully.");
    }

    public async Task<List<Component>> GetAllAsync()
    {
        return await _dbContext.Components.ToListAsync();
    }

    public async Task<Component> GetByIdAsync(int id)
    {
        return await _dbContext.Components.FindAsync(id);
    }

    public async Task<ServiceResponse> UpdateAsync(Component entity)
    {
        var component = await _dbContext.Components.FindAsync(entity.Id);
        if (component == null)
            return new ServiceResponse(false, "Component not found.");

        component.Name = entity.Name;

        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Component updated successfully.");
    }

    public async Task<List<Component>> GetComponentsByCharacterIdAsync(int characterId)
    {
        return await _dbContext.Components
            .Where(c => c.CharacterComponents.Any(cc => cc.CharacterId == characterId))
            .ToListAsync();
    }
}
