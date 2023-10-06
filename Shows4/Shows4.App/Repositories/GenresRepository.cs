using Shows4.App.Data;
namespace Shows4.App.Repositories;

public class GenresRepository
{
    private readonly ApplicationDbContext _ctx;
    private readonly ILogger<GenresRepository> _logger; 

    public GenresRepository(ApplicationDbContext ctx, ILogger<GenresRepository> logger)
    {
        _ctx = ctx;
        _logger = logger;
    }
    //Create
    public async Task<Genre> AddGenreAsync(string name)
    { 
        Genre genre = new() { Name = name };
        return await AddGenreAsync(genre);
    }
    public async Task<Genre> AddGenreAsync(Genre genre)
    {
        _ = _ctx.Genres.Add(genre);
        _= await _ctx.SaveChangesAsync();
        return genre;
    }

    //Delete
    public async Task<Genre> GetByIdAsync (int id)
    {
        return await _ctx.Genres
            .Where(g => g.Id == id).FirstOrDefaultAsync();   }

    public async Task DeleteByIdAsync(int id)
    {
       int result = await _ctx.Genres.Where(g => g.Id == id).ExecuteDeleteAsync();
        if (result == 0) 
        {
            _logger.LogInformation($"Tryed to delete Genre with Id: {id} but it did not exist");
        }
    }
    //Details
    public async Task<List<Genre>> GetAsync(int offsett, int pageSize)
    {
        return await _ctx.Genres
            .OrderBy(g => g.Id)
            .Skip(offsett)
            .Take(pageSize).ToListAsync();
    }
    public async Task<List<Genre>> GetByPageAsync(int page, int pageSize)
    {
        return await GetAsync(page*pageSize, pageSize);
    }
    //Update
    public async Task UpdateAsync(Genre genre)
    {
        _ctx.Attach(genre).State = EntityState.Modified;
        _= await _ctx.SaveChangesAsync();
    }
    public async Task UpdateAsync(int id, string Name)
    {
        _ = await _ctx.Genres.Where(g => g.Id == id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(p => p.Name, Name));
    }
    //Index
    public async Task<List<Genre>> GetAllAsync()
    {
        return await _ctx.Genres.ToListAsync();
    }
}
