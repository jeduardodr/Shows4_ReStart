using Microsoft.EntityFrameworkCore;

namespace Shows4.App.Repositories;

public class EpisodeRepository
{
    private readonly ApplicationDbContext _ctx;
    private readonly ILogger<CountryRepository> _logger;

    public EpisodeRepository(ApplicationDbContext ctx, ILogger<CountryRepository> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }
    public async Task<IList<Episode>> GetEpisodesAsync(int seasonId)
    {
            return await _ctx.Episodes.Where(s => s.SeasonId == seasonId).ToListAsync();
     
    }
    public async Task<Season> GetSeasonByIdAsync(int id) //*
    {
        return await _ctx.Seasons.FirstOrDefaultAsync(s => s.Id == id);
    }
    //create
    public async Task AddEpisodeAsync(Episode episode)
    {
        _ctx.Episodes.Add(episode);
        await _ctx.SaveChangesAsync();
    }
    //Delete
    public async Task<Episode> FindEpisodeAsync(int? id) //verifica se episodio existe
    {
        if (id == null || _ctx.Episodes == null)
        {
            return null;
        }

        var episode = await _ctx.Episodes.FirstOrDefaultAsync(m => m.Id == id);
        return episode;
    }
    public async Task<Season> GetEpisodeByIdAsync(int id)//*
    {
        return await _ctx.Seasons.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task DeleteEpisodeAsync(Episode episode) //delete Episodio
    {
        if (episode != null)
        {
            _ctx.Episodes.Remove(episode);
            await _ctx.SaveChangesAsync();
        }
    }
    //Update
    public async Task UpdateEpisodeAsync(Episode episode)
    {
        _ctx.Attach(episode).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
    }
    public async Task<Episode> GetEpisodeAsync(int id)
    {
        return await _ctx.Episodes.FirstOrDefaultAsync(m => m.Id == id);
    }
}
