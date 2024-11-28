

namespace TfdThreeTier.BuisnessLogic.Entities.JoinTables;
public class ComponentMaterial
{
    public int ComponentId { get; set; }
    public Component? Component { get; set; }

    public int MaterialId { get; set; }
    public Material? Material { get; set; }
}