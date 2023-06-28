using Microsoft.EntityFrameworkCore;
using ShoppingApi.Data;

namespace ShoppingApi.Controllers;

public class StatusLookup : ILookupTheStatus
{

    private readonly ShoppingDataContext _context;

    public StatusLookup(ShoppingDataContext context)
    {
        _context = context;
    }

    public async Task<GetStatusResponse> GetCurrentStatusAsync()
    {
        // find the latest status saved in the database.
        // if the status was saved within 10 minutes from now, use that - return that.
        // if there is no status, or it is stale (>10 old) write a new status to the datbase, and return THAT.
        var savedStatus = await _context.StatusMessages.OrderBy(m => m.LastChecked).FirstOrDefaultAsync();
        if (savedStatus is null)
        {
            var entityToSave = new StatusEntity
            {
                LastChecked = DateTimeOffset.Now,
                Message = "Looks Good"
            };
            _context.StatusMessages.Add(entityToSave);
            await _context.SaveChangesAsync();
        }
        else
        {
            // check if it is "stale"... 

        }
        
        var response = new GetStatusResponse
        {
            Message = "Looks Good Here",
            LastChecked = DateTimeOffset.Now
        };
        return Task.FromResult(response);
    }
}
