using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;
using Shows4.App.Data.Entities;

namespace Shows4.App.Repositories;

public class CountryRepository
{
    private readonly ApplicationDbContext _ctx;
    private readonly ILogger<CountryRepository> _logger;

    public CountryRepository(ApplicationDbContext ctx, ILogger<CountryRepository> logger) 
    {
        _ctx = ctx;
        _logger = logger;
    }

    public async Task<Country> AddCountryAsync (string alpha2Code, string name) 
    {
        Country country = new() { Name = name, Alpha2Code = alpha2Code};
        return await AddCountryAsync(country);
    }
    public async Task<Country> AddCountryAsync (Country country)
    {
        _ = _ctx.Countries.Add(country);
        _ = await _ctx.SaveChangesAsync();
        return country;
    }
    
    //Delete
public async Task<Country> GetByIdAsync(int id)
    {
        return await _ctx.Countries
                            .Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task DeleteByIdAsync (int id )
    {
        int result = await _ctx.Countries
                                    .Where(c => c.Id == id).ExecuteDeleteAsync();
        if ( result == 0 )
        {
            _logger.LogInformation($"Tryed to Delete country with Id: {id} but it did not exist");
        }
    }
    //Details
    public async Task<List<Country>> GetAsync(int offset, int pageSize)
    {
        return await _ctx.Countries
            .OrderBy(c=> c.Id)
            .Skip(offset)
            .Take(pageSize).ToListAsync();
    }
    public async Task<List<Country>> GetByPageAsync(int page, int pageSize)
    {
        return await GetAsync(page * pageSize, pageSize);
    }

    //Update
    public async Task UpdateAsync(Country country)
    {
        _ctx.Attach(country).State = EntityState.Modified;
        _ = await _ctx.SaveChangesAsync();
    }
    public async Task UpdateAsync(int id, string code, string name)
    {
        _ = await _ctx.Countries.Where(c => c.Id == id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(p => p.Name, name)
            .SetProperty(p => p.Alpha2Code, code));
    }

    //INDEX
    public async Task<List<Country>> GetAllAsync()
    {
        return await _ctx.Countries .ToListAsync();
    }
}
