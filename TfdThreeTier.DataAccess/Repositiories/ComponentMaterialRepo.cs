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
public class ComponentMaterialRepo : IComponentMaterialRepo
{
    private readonly ApplicationDbContext _dbContext;

    public ComponentMaterialRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ComponentMaterial> CreateAsync(ComponentMaterial entity)
    {
        try
        {
            _dbContext.ComponentMaterials.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error creating component material: {ex.Message}");
            throw;
        }
    }

    public async Task<ComponentMaterial> GetByIdAsync(int id)
    {
        return await _dbContext.ComponentMaterials.FindAsync(id);
    }

    public async Task<List<ComponentMaterial>> GetAllAsync()
    {
        return await _dbContext.ComponentMaterials.ToListAsync();
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var entity = await _dbContext.ComponentMaterials.FindAsync(id);
        if (entity == null)
        {
            return new ServiceResponse(false, "ComponentMaterial not found.");
        }

        _dbContext.ComponentMaterials.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "ComponentMaterial deleted successfully.");
    }

    public async Task<ServiceResponse> UpdateAsync(ComponentMaterial entity)
    {
        _dbContext.ComponentMaterials.Update(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "ComponentMaterial updated successfully.");
    }

    public async Task<List<ComponentMaterial>> GetComponentMaterialsByComponentIdAsync(int componentId)
    {
        return await _dbContext.ComponentMaterials
            .Where(cm => cm.ComponentId == componentId)
            .ToListAsync();
    }
}
