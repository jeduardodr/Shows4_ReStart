using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shows4.App.Data;
using Shows4.App.Data.Entities;
using Shows4.App.Models;
using System.Runtime.InteropServices;

namespace Shows4.App.Repositories;

public class WriterRepository
{
    private readonly ApplicationDbContext _ctx;
    private readonly ILogger<WriterRepository> _logger;

    public WriterRepository(ApplicationDbContext ctx, ILogger<WriterRepository> logger )
    {
        _ctx = ctx;
        _logger = logger;
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

    
}
