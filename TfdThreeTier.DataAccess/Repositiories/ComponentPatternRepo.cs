using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories;
public class ComponentPatternRepo : IComponentPatternRepo
{
    private readonly ApplicationDbContext _dbContext;

    public ComponentPatternRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ComponentPattern> CreateAsync(ComponentPattern entity)
    {
        try
        {
            _dbContext.ComponentPatterns.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating component pattern: {ex.Message}");
            throw;
        }
    }

    public async Task<ComponentPattern> GetByIdAsync(int id)
    {
        return await _dbContext.ComponentPatterns.FindAsync(id);
    }

    public async Task<List<ComponentPattern>> GetAllAsync()
    {
        return await _dbContext.ComponentPatterns.ToListAsync();
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var entity = await _dbContext.ComponentPatterns.FindAsync(id);
        if (entity == null)
        {
            return new ServiceResponse(false, "ComponentPattern not found.");
        }

        _dbContext.ComponentPatterns.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "ComponentPattern deleted successfully.");
    }

    public async Task<ServiceResponse> UpdateAsync(ComponentPattern entity)
    {
        _dbContext.ComponentPatterns.Update(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "ComponentPattern updated successfully.");
    }

    public async Task<List<ComponentPattern>> GetComponentPatternsByComponentIdAsync(int componentId)
    {
        return await _dbContext.ComponentPatterns
            .Where(cp => cp.ComponentId == componentId)
            .ToListAsync();
    }
}
