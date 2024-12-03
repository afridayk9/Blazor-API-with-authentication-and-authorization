using Microsoft.EntityFrameworkCore;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories;
public class ComponentPatternRepo : IComponentPatternRepo
{
    private readonly ApplicationDbContext _context;

    public ComponentPatternRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ComponentPattern> CreateAsync(ComponentPattern entity)
    {
        _context.ComponentPatterns.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<ComponentPattern> GetByIdAsync(int componentId, int patternId)
    {
        return await _context.ComponentPatterns
            .FirstOrDefaultAsync(cp => cp.ComponentId == componentId && cp.PatternId == patternId);
    }

    public async Task<List<ComponentPattern>> GetAllAsync()
    {
        return await _context.ComponentPatterns.ToListAsync();
    }

    public async Task<ServiceResponse> DeleteAsync(int componentId, int patternId)
    {
        var componentPattern = await _context.ComponentPatterns
            .FirstOrDefaultAsync(cp => cp.ComponentId == componentId && cp.PatternId == patternId);
        if (componentPattern == null)
        {
            return new ServiceResponse(false, "ComponentPattern not found.");
        }

        _context.ComponentPatterns.Remove(componentPattern);
        await _context.SaveChangesAsync();
        return new ServiceResponse(true, "ComponentPattern deleted successfully.");
    }

    public async Task<ServiceResponse> UpdateAsync(ComponentPattern entity)
    {
        _context.ComponentPatterns.Update(entity);
        await _context.SaveChangesAsync();
        return new ServiceResponse(true, "ComponentPattern updated successfully.");
    }

    public async Task<List<ComponentPattern>> GetComponentPatternsByComponentIdAsync(int componentId)
    {
        return await _context.ComponentPatterns
            .Where(cp => cp.ComponentId == componentId)
            .ToListAsync();
    }
}
