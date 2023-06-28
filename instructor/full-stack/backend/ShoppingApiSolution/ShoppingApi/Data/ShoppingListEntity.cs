namespace ShoppingApi.Data;

public class ShoppingListEntity
{
    public int Id { get; set; }
    public string Description { get; init; } = string.Empty;
    public bool Purchased { get; init; }

    public DateTimeOffset DateAdded { get; set; }
    
}