using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
public class PatternRepo : IPatternRepo
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<PatternRepo> _logger;

    public PatternRepo(ApplicationDbContext dbContext, ILogger<PatternRepo> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<ServiceResponse> CreateAsync(Pattern entity)
    {
        var check = await _dbContext.Patterns.FirstOrDefaultAsync(c => c.PatternNumber == entity.PatternNumber);
        if (check != null)
            return new ServiceResponse(false, "Pattern already exists.");

        _dbContext.Patterns.Add(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Pattern created successfully.");
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var pattern = await _dbContext.Patterns.FindAsync(id);
        if (pattern == null)
            return new ServiceResponse(false, "Pattern not found.");

        _dbContext.Patterns.Remove(pattern);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Pattern deleted successfully.");
    }

    public async Task<List<Pattern>> GetAllAsync()
    {
        return await _dbContext.Patterns.ToListAsync();
    }

    public async Task<Pattern> GetByIdAsync(int id)
    {
        return await _dbContext.Patterns.FindAsync(id);
    }

    public async Task<ServiceResponse> UpdateAsync(Pattern entity)
    {
        var pattern = await _dbContext.Patterns.FindAsync(entity.Id);
        if (pattern == null)
            return new ServiceResponse(false, "Pattern not found.");

        pattern.PatternNumber = entity.PatternNumber;

        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Pattern updated successfully.");
    }

    public async Task<List<Pattern>> GetPatternsByMaterialIdAsync(int materialId)
    {
        try
        {
            return await _dbContext.Patterns
                .Where(p => p.MaterialPatterns.Any(mp => mp.MaterialId == materialId))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching patterns by material ID");
            throw;
        }
    }

    public async Task<List<Pattern>> GetPatternsByComponentIdAsync(int componentId)
    {
        try
        {
            return await _dbContext.Patterns
                .Where(p => p.ComponentPatterns.Any(cp => cp.ComponentId == componentId))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching patterns by component ID");
            throw;
        }
    }

    public async Task<List<Pattern>> GetPatternsByCharacterIdAsync(int characterId)
    {
        try
        {
            return await _dbContext.Patterns
                .Where(p => p.CharacterPatterns.Any(cp => cp.CharacterId == characterId))
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching patterns by character ID");
            throw;
        }
    }
}
