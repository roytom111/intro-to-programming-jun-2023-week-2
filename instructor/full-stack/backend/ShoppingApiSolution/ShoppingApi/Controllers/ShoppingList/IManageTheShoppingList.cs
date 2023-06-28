namespace ShoppingApi.Controllers.ShoppingList;

public interface IManageTheShoppingList
{
    Task<CollectionResponse<ShoppingListItemModel>> GetShoppingListAsync();
}