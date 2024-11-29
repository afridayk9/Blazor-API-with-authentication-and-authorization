using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfdThreeTier.BuisnessLogic.Entities.JoinTables;
public class ComponentPattern
{
    public int ComponentId { get; set; }
    public Component Component { get; set; }
    public int PatternId { get; set; }
    public Pattern Pattern { get; set; }
}
