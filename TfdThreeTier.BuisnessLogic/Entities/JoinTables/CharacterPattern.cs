using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfdThreeTier.BuisnessLogic.Entities.JoinTables;
public class CharacterPattern
{
    public int CharacterId { get; set; }
    public Character? Character { get; set; }
    public int PatternId { get; set; }
    public Pattern? Pattern { get; set; }
    public string? MaterialDropChance { get; set; } 
}
