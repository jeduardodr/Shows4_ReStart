using Microsoft.EntityFrameworkCore;

namespace Shows4.App.Pages.Entities.Series;
[Authorize]
public class IndexModel : PageModel
{
    private readonly SerieRepository _serieRepository;
    private readonly ApplicationDbContext _context;

    public IndexModel(SerieRepository serieRepository, ApplicationDbContext context)
    {
        _serieRepository = serieRepository;
        _context = context;
    }

    public IList<Serie> Serie { get; set; } = default!;

    public async Task OnGetAsync()
    {

        Serie = await _serieRepository.GetSeriesWithIncludes();
        foreach (var serie in Serie)
        {
            // Verifique se existem registros relacionados
            var relatedRecords = _context.Seasons.Where(m => m.SerieId == serie.Id).ToList();
            if (relatedRecords.Count > 0)
            {
                serie.CanDelete = false;
            }
            else
            {
                serie.CanDelete = true;
            }
        }
    }
}
