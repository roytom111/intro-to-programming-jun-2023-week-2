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
        
        var savedStatus = await _context.StatusMessages
            .OrderByDescending(m => m.LastChecked)
            .FirstOrDefaultAsync();
       
        if (savedStatus is null) // This is the first time we've run this, and there is no StatusEntity saved.
        {
            var entityToSave = GetFreshStatusEntity();
            _context.StatusMessages.Add(entityToSave);
            await _context.SaveChangesAsync();
            savedStatus = entityToSave;
        }
        else
        {
            
            if(IsStale(savedStatus)) // Ok, We have one, but let's update it if needed.
            {
                var entityToSave = GetFreshStatusEntity();
                _context.StatusMessages.Add(entityToSave);
                await _context.SaveChangesAsync();
                savedStatus = entityToSave;
            }

        }
        
        var response = new GetStatusResponse // Mapping that Entity to a Model.
        {
            Message = savedStatus!.Message,
            LastChecked = savedStatus.LastChecked,
        };
        return response;
    }

    private bool IsStale(StatusEntity statusEntity)
    {
        var stale = TimeSpan.FromMinutes(5);
        return DateTime.Now.ToUniversalTime() - statusEntity.LastChecked > stale;

    }
    private StatusEntity GetFreshStatusEntity()
    {
        return new StatusEntity
        {
            LastChecked = DateTime.Now.ToUniversalTime(),
            Message = "Looks Good"
        };
    }
}
