using TfdThreeTier.BuisnessLogic.Entities.JoinTables;

namespace TfdThreeTier.BuisnessLogic.Entities;
public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<CharacterComponent>? CharacterComponents { get; set; }
    public ICollection<CharacterPattern>? CharacterPatterns { get; set; }
}
