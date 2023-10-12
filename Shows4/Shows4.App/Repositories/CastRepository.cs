using Shows4.App.Data;
using Shows4.App.Models;

namespace Shows4.App.Repositories;

public class CastRepository
{
    private readonly ApplicationDbContext _ctx;
    public CastRepository(ApplicationDbContext ctx, ILogger<CastRepository> logger)
    {
        _ctx = ctx;

    }
    public async Task<CastModel> GetCastModelAsync(int castId)
    {
        var model = await (from cast in _ctx.Casts
                           join country in _ctx.Countries on cast.CountryId equals country.Id
                           where cast.Id == castId
                           select new CastModel
                           {
                              CastId = cast.Id,
                               CastName = cast.Name,
                               CountryName = cast.Name,
                           }).FirstOrDefaultAsync();
        return model;
    }
    public SelectList GetCountries()
    {
        return new SelectList(_ctx.Countries, "Id", "Name");
    }
    
    //get index 
    public async Task<List<Country>> GetAllAsync()
    {
        return await _ctx.Countries.ToListAsync();
    }
    public async Task<IList<Cast>> GetCastAsync()
    {
        if (_ctx.Casts != null)
        {
            return await _ctx.Casts.Include(w => w.Country).ToListAsync();
        }

        return new List<Cast>();
    }
    //Details
    public async Task<(Cast cast, IList<Cast> casts)> GetCastAndListAsync(int? id)
    {
        if (id == null)
        {
            return (null, null);
        }
        var casts = await _ctx.Casts.Include(w => w.Country).ToListAsync();
        var cast = await _ctx.Casts.FirstOrDefaultAsync(m => m.Id == id);
        return (cast, casts);
    }
    // ADD
    public async Task AddCastAsync(Cast cast)
    {
        _ctx.Casts.Add(cast);
        await _ctx.SaveChangesAsync();
    }
    //Delete
    public async Task<Cast> FindCastById(int? id)
    {
        if (id == null)
        {
            return null;
        }
        return await _ctx.Casts.FindAsync(id);
    }
    public async Task RemoveCast(Cast cast)
    {
        _ctx.Casts.Remove(cast);
        await _ctx.SaveChangesAsync();
    }
    //Edit

    public async Task<Cast> GetCastAsync(int id)
    {
        if (_ctx.Casts == null)
        {
            return null;
        }
        return await _ctx.Casts.FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task UpdateCastAsync(Cast cast)
    {
        _ctx.Attach(cast).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }
    public bool CastExists(int id)
    {
        return _ctx.Casts.Any(e => e.Id == id);
    }
}
