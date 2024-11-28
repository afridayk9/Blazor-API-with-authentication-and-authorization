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
public class MaterialRepo : IMaterialRepo
{
    private readonly ApplicationDbContext _dbContext;

    public MaterialRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse> CreateAsync(Material entity)
    {
        var check = await _dbContext.Materials.FirstOrDefaultAsync(m => m.Name == entity.Name);
        if (check != null)
            return new ServiceResponse(false, "Material already exists.");

        _dbContext.Materials.Add(entity);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Material created successfully.");
    }

    public async Task<ServiceResponse> DeleteAsync(int id)
    {
        var material = await _dbContext.Materials.FindAsync(id);
        if (material == null)
            return new ServiceResponse(false, "Material not found.");

        _dbContext.Materials.Remove(material);
        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Material deleted successfully.");
    }

    public async Task<List<Material>> GetAllAsync()
    {
        return await _dbContext.Materials.ToListAsync();
    }

    public async Task<Material> GetByIdAsync(int id)
    {
        return await _dbContext.Materials.FindAsync(id);
    }

    public async Task<ServiceResponse> UpdateAsync(Material entity)
    {
        var material = await _dbContext.Materials.FindAsync(entity.Id);
        if (material == null)
            return new ServiceResponse(false, "Material not found.");

        material.Name = entity.Name;

        await _dbContext.SaveChangesAsync();
        return new ServiceResponse(true, "Material updated successfully.");
    }
}
