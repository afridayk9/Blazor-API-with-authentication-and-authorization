namespace TfdThreeTier.Client.ViewModels;

public class ComponentDetailViewModel
{
    public int Id { get; set; }
    public string ComponentName { get; set; }
    public List<MaterialDetailViewModel> Materials { get; set; } = new();
    public List<PatternDetailViewModel> Patterns { get; set; } = new();
}
