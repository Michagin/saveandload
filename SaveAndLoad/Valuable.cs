namespace SaveAndLoad;

public class Valuable : IValuable
{
    public required string Category { get; set; }
    public string Id { get; set; }
    public string Text { get; set; } = null!;
    public required string Price { get; set; }

    public string GetValue()
    {
        return Price;
    }
    
}