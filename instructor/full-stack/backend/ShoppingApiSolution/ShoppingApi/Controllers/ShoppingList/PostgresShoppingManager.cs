using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data;

namespace ShoppingApi.Controllers.ShoppingList;

public class PostgresShoppingManager : IManageTheShoppingList
{
    private readonly ShoppingDataContext _context;

    public PostgresShoppingManager(ShoppingDataContext context)
    {
        _context = context;
    }

    public async Task<CollectionResponse<ShoppingListItemModel>> GetShoppingListAsync()
    {
        var results = await _context.ShoppingList
            .Select(item => new ShoppingListItemModel
            {
                Id = item.Id.ToString(),
                Description = item.Description,
                Purchased = item.Purchased,
            })
            .ToListAsync();

        return new CollectionResponse<ShoppingListItemModel>()
        {
            Data = results
        };
    }
}
