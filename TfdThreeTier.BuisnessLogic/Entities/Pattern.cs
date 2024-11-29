using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.BuisnessLogic.Entities;
public class Pattern
{
    public int Id { get; set; }
    public string PatternNumber { get; set; }
    public ICollection<MaterialPattern>? MaterialPatterns { get; set; }
    public ICollection<ComponentPattern>? ComponentPatterns { get; set; }
    public ICollection<CharacterPattern>? CharacterPatterns { get; set; }

}
