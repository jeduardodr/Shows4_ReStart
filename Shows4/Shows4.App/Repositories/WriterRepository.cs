using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;
using Shows4.App.Models;

namespace Shows4.App.Repositories;

public class WriterRepository
{
    private readonly ApplicationDbContext _ctx;
       public WriterRepository(ApplicationDbContext ctx, ILogger<WriterRepository> logger )
    {
        _ctx = ctx;
       
    }
    public async Task<WriterModel> GetWriteModelAsync(int writeId)
    {
        var model = await (from writer in _ctx.Writers
                           join country in _ctx.Countries on writer.CountryId equals country.Id
                           where writer.Id == writeId
                           select new WriterModel
                           {
                               WriteId = writer.Id,
                               WriteName = writer.Name,
                               CountryName = writer.Name,
                           }).FirstOrDefaultAsync();
        return model;
    }
    //Get Countries 
    public SelectList GetCountries()
    {
        return new SelectList(_ctx.Countries, "Id", "Name");
    }
    // ADD
    public async Task AddWriterAsync(Writer writer)
    {
        _ctx.Writers.Add(writer);
        await _ctx.SaveChangesAsync();
    }
    //get
    public async Task<List<Country>> GetAllAsync()
    {
        return await _ctx.Countries.ToListAsync();
    }

    public async Task<IList<Writer>> GetWritersAsync()
    {
        if (_ctx.Writers != null)
        {
            return await _ctx.Writers.Include(w => w.Country).ToListAsync();
        }

        return new List<Writer>();
    }
    //Delete
    public async Task<Writer> FindWriterById(int? id)
    {
        if (id == null)
        {
            return null;
        }
        return await _ctx.Writers.FindAsync(id);
    }
    public async Task RemoveWriter(Writer writer)
    {
        _ctx.Writers.Remove(writer);
        await _ctx.SaveChangesAsync();
    }
    //Details
    public async Task<(Writer writer, IList<Writer> writers)> GetWriterAndListAsync(int? id)
    {
        if (id == null)
        {
            return (null, null);
        }
        var writers = await _ctx.Writers.Include(w => w.Country).ToListAsync();
        var writer = await _ctx.Writers.FirstOrDefaultAsync(m => m.Id == id);
        return (writer, writers);
    }
    //Edit
  
    public async Task<Writer> GetWriterAsync(int id)
    {
        if ( _ctx.Writers == null)
        {
            return null;
        }
        return await _ctx.Writers.FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task UpdateWriterAsync(Writer writer)
    {
        _ctx.Attach(writer).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }
    public bool WriterExists(int id)
    {
        return _ctx.Writers.Any(e => e.Id == id);
    }
}
