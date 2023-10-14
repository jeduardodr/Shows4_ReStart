using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;

namespace Shows4.App.Repositories;

public class SeasonRepository
{
    private readonly ApplicationDbContext _ctx;
    private readonly ILogger<CountryRepository> _logger;

    public SeasonRepository(ApplicationDbContext ctx, ILogger<CountryRepository> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }
    //-------------------VERIFICAR ISTO 
    public async Task<IList<Season>> GetSeasonAsync()
    {
        if (_ctx.Seasons != null)
        {
            return await _ctx.Seasons.ToListAsync();
        }

        return new List<Season>();
    }
    public SelectList GetSeries()
    {
        return new SelectList(_ctx.Series, "Id", "Name");
    }
    //-----------------------------------
    //Create
    

    public async Task AddAsync(Season season)//*
    {
        _ctx.Seasons.Add(season);
        await _ctx.SaveChangesAsync();
    }
    //index 
    public async Task<IList<Season>> GetSeasonsBySerieIdAsync(int serieId)//*
    {
        return await _ctx.Seasons.Where(s => s.SerieId == serieId).ToListAsync();
    }

    public async Task<Serie> GetSerieByIdAsync(int id) //*
    {
        return await _ctx.Series.FirstOrDefaultAsync(s => s.Id == id);
    }
    //update 
    public async Task<Season> GetSeasonByIdAsync(int id)//*
    {
        return await _ctx.Seasons.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task UpdateSeasonAsync(Season season)//*
    {
        _ctx.Attach(season).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public bool SeasonExists(int id)//*
    {
        return _ctx.Seasons.Any(e => e.Id == id);
    }
    //delete
    public async Task<Season> GetSeason(int? id)
    {
        if (id == null || _ctx.Seasons == null)
        {
            return null;
        }

        var season = await _ctx.Seasons.FirstOrDefaultAsync(m => m.Id == id);
        return season;
    }

    public async Task DeleteSeason(int? id)
    {
        if (id == null || _ctx.Seasons == null)
        {
            return;
        }

        var season = await _ctx.Seasons.FindAsync(id);

        if (season != null)
        {
            _ctx.Seasons.Remove(season);
            await _ctx.SaveChangesAsync();
        }
    }
}
