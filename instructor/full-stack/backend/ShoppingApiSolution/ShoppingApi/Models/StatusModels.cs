namespace ShoppingApi.Models;

public record GetStatusResponse
{
    public string Message { get; init; } = string.Empty;
    public DateTime LastChecked { get; init; }
}