namespace ShoppingApi.Controllers.ShoppingList;

public class ShoppingListController : ControllerBase
{

    private readonly IManageTheShoppingList _shoppingListManager;

    public ShoppingListController(IManageTheShoppingList shoppingListManager)
    {
        _shoppingListManager = shoppingListManager;
    }

    [HttpGet("/shopping-list")]
    public async Task<ActionResult> GetShoppingList()
    {

        CollectionResponse<ShoppingListItemModel> response = await _shoppingListManager.GetShoppingListAsync();
        
        return Ok(response);
        
    }
}
