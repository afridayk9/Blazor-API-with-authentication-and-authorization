using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.DataAccess.Interfaces;
public interface ICharacterPatternRepo
{
    Task<List<CharacterPattern>> GetCharacterPatternsByCharacterIdAsync(int characterId);
}
