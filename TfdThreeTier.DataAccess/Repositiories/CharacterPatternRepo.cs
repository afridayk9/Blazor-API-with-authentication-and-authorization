using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.DTOs;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories
{
    public class CharacterPatternRepo : ICharacterPatternRepo
    {
        private readonly ApplicationDbContext _context;

        public CharacterPatternRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CharacterPattern> CreateAsync(CharacterPattern entity)
        {
            _context.CharacterPatterns.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CharacterPattern> GetByIdAsync(int characterId, int patternId)
        {
            return await _context.CharacterPatterns
                .FirstOrDefaultAsync(cp => cp.CharacterId == characterId && cp.PatternId == patternId);
        }

        public async Task<List<CharacterPattern>> GetAllAsync()
        {
            return await _context.CharacterPatterns.ToListAsync();
        }

        public async Task<ServiceResponse> DeleteAsync(int characterId, int patternId)
        {
            var characterPattern = await _context.CharacterPatterns
                .FirstOrDefaultAsync(cp => cp.CharacterId == characterId && cp.PatternId == patternId);
            if (characterPattern == null)
            {
                return new ServiceResponse(false, "CharacterPattern not found.");
            }

            _context.CharacterPatterns.Remove(characterPattern);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "CharacterPattern deleted successfully.");
        }

        public async Task<ServiceResponse> UpdateAsync(CharacterPattern entity)
        {
            _context.CharacterPatterns.Update(entity);
            await _context.SaveChangesAsync();
            return new ServiceResponse(true, "CharacterPattern updated successfully.");
        }

        public async Task<List<CharacterPattern>> GetCharacterPatternsByCharacterIdAsync(int characterId)
        {
            return await _context.CharacterPatterns                
                .Where(cp => cp.CharacterId == characterId)
                .ToListAsync();
        }
    }
}



