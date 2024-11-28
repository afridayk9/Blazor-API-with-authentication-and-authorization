using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfdThreeTier.BuisnessLogic.Entities.JoinTables;
public class CharacterComponent
{
    public int CharacterId { get; set; }
    public Character? Character { get; set; }

    public int ComponentId { get; set; }
    public Component? Component { get; set; }
}
