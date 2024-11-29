using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfdThreeTier.BuisnessLogic.Entities.JoinTables;
public class MaterialPattern
{
    public int MaterialId { get; set; }
    public Material Material { get; set; }
    public int PatternId { get; set; }
    public Pattern Pattern { get; set; }
}
    
