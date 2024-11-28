using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.BuisnessLogic.Entities;
public class Material
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<ComponentMaterial>? ComponentMaterials { get; set; }
}
