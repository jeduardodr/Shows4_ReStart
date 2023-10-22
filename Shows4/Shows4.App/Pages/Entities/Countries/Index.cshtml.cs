using Microsoft.EntityFrameworkCore;

namespace Shows4.App.Pages.Entities.Countries;
[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly CountryRepository _countryRepository;
    private readonly ApplicationDbContext _context;

    public IndexModel(CountryRepository countryRepository, 
        ApplicationDbContext context)
    {
        _countryRepository = countryRepository;
        _context = context; 
    }

    public IList<Country> Countries { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Countries = await _countryRepository.GetAllAsync();
        foreach (var country in Countries)
        {
            // Verifique se existem registros relacionados
            var relatedRecordsSerie = _context.Series.Where(m => m.CountryId == country.Id).ToList();
            var relatedRecordsCast = _context.Casts.Where(m => m.CountryId == country.Id).ToList();
            var relatedRecordsWriter = _context.Writers.Where(m => m.CountryId == country.Id).ToList();
            if (relatedRecordsSerie.Count > 0 || relatedRecordsCast.Count > 0 || relatedRecordsWriter.Count > 0)
            {
                country.CanDelete = false;
            }
            else
            {
                country.CanDelete = true;
            }
        }


    }
}
