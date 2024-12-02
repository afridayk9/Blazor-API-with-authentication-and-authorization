using Microsoft.EntityFrameworkCore;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositories
{
    public class MaterialPatternRepo : IMaterialPatternRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public MaterialPatternRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MaterialPattern> CreateAsync(MaterialPattern entity)
        {
            try
            {
                _dbContext.MaterialPatterns.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating material pattern: {ex.Message}");
                throw;
            }
        }

        public async Task<MaterialPattern> GetByIdAsync(int id)
        {
            return await _dbContext.MaterialPatterns.FindAsync(id);
        }

        public async Task<List<MaterialPattern>> GetAllAsync()
        {
            return await _dbContext.MaterialPatterns.ToListAsync();
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var entity = await _dbContext.MaterialPatterns.FindAsync(id);
            if (entity == null)
            {
                return new ServiceResponse(false, "MaterialPattern not found.");
            }

            _dbContext.MaterialPatterns.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return new ServiceResponse(true, "MaterialPattern deleted successfully.");
        }

        public async Task<ServiceResponse> UpdateAsync(MaterialPattern entity)
        {
            _dbContext.MaterialPatterns.Update(entity);
            await _dbContext.SaveChangesAsync();
            return new ServiceResponse(true, "MaterialPattern updated successfully.");
        }

        public async Task<List<MaterialPattern>> GetMaterialPatternsByMaterialIdAsync(int materialId)
        {
            return await _dbContext.MaterialPatterns
                .Where(mp => mp.MaterialId == materialId)
                .ToListAsync();
        }
    }
}

