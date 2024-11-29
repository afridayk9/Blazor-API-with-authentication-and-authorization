using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;
using TfdThreeTier.DataAccess.Data;
using TfdThreeTier.DataAccess.Interfaces;

namespace TfdThreeTier.DataAccess.Repositiories;
public class CharacterPatternRepo(ApplicationDbContext dbContext) : ICharacterPatternRepo
{
    public async Task<List<CharacterPattern>> GetCharacterPatternsByCharacterIdAsync(int characterId)
    {
        return await dbContext.CharacterPatterns
            .Where(cp => cp.CharacterId == characterId)
            .ToListAsync();
    }
}
