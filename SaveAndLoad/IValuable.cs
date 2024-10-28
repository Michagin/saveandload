namespace SaveAndLoad;

public partial interface IValuable
{
    public string Category { get; set; }
    public string Id { get; set; }
    public string Text { get; set; }
    public string Price { get; set; }

    public string GetValue();
}