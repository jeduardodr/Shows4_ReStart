using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;

namespace Shows4.App.Repositories;

public class SerieRepository
{
    private readonly ApplicationDbContext _ctx;
    public SerieRepository(ApplicationDbContext ctx, ILogger<SerieRepository> logger)
    {
        _ctx = ctx;

    }
    //Get Countries
    public SelectList GetCountries()
    {
        return new SelectList(_ctx.Countries, "Id", "Name");
    }

    //Get Genres
    public SelectList GetGenres()
    {
        return new SelectList(_ctx.Genres, "Id", "Name");
    }
    public async Task<IList<Serie>> GetSerieAsync()
    {
        if (_ctx.Series != null)
        {
            return await _ctx.Series.Include(w => w.Country)
                .Include(s=> s.Genre).ToListAsync();
        }

        return new List<Serie>();
    }
    //index
    public async Task<IList<Serie>> GetSeriesWithIncludes()
    {
        if (_ctx.Series != null)
        {
            return await _ctx.Series
            .Include(s => s.Country)
            .Include(s => s.Genre).ToListAsync();
        }
        return new List<Serie>();
    }
    //create
    public async Task AddSerieAsync(Serie serie)
    {
        _ctx.Series.Add(serie);
        await _ctx.SaveChangesAsync();
    }
    //delete
    public async Task<Serie> GetSerie(int? id)
    {
        if (id == null || _ctx.Series == null)
        {
            return null;
        }

        var serie = await _ctx.Series.FirstOrDefaultAsync(m => m.Id == id);
        return serie;
    }

    public async Task DeleteSerie(int? id)
    {
        if (id == null || _ctx.Series == null)
        {
            return;
        }

        var serie = await _ctx.Series.FindAsync(id);

        if (serie != null)
        {
            _ctx.Series.Remove(serie);
            await _ctx.SaveChangesAsync();
        }
    }
    //Details
    public async Task<(Serie serie, IList<Serie> series)> GetSerieAndListAsync(int id)
    {
        var serie = await _ctx.Series.Include(w => w.Country)
                                     .Include(s => s.Genre)
                                     .FirstOrDefaultAsync(m => m.Id == id);

        if (serie == null)
        {
            throw new ArgumentException("Serie with the given id not found");
        }

        var series = await _ctx.Series.Include(w => w.Country)
                                      .Include(s => s.Genre).ToListAsync();

        return (serie, series);
    }
    public async Task<(Serie serie, IList<Serie> series)> GetSerieAndListAsync(int? id)
    {
        if (id == null)
        {
            return (null, null);
        }
        var series = await _ctx.Series.Include(w => w.Country)
                                      .Include(s => s.Genre).ToListAsync();
        var serie = await _ctx.Series.FirstOrDefaultAsync(m => m.Id == id);
        return (serie, series);
    }
    public async Task<Serie> GetSerieByIdAsync(int id)
    {
        return await _ctx.Series.FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task<Serie> GetSeriesByIdAsync(int id)
    {
        return await _ctx.Series.FindAsync(id);
    }
    //edit
    public bool SerieExists(int id)
    {
        return _ctx.Series.Any(e => e.Id == id);
    }

    public async Task UpdateSerieAsync(Serie serie)
    {
        _ctx.Attach(serie).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

}
