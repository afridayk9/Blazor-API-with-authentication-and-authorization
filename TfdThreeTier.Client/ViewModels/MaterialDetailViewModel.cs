namespace TfdThreeTier.Client.ViewModels;

public class MaterialDetailViewModel
{
    public string MaterialName { get; set; }
    public List<PatternDetailViewModel> Patterns { get; set; } = new();
}
