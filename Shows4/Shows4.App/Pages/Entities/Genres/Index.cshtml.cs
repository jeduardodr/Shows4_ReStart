using Microsoft.EntityFrameworkCore;

namespace Shows4.App.Pages.Entities.Genres;
[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly GenresRepository _genresRepository;
    private readonly ApplicationDbContext _context;

    public IndexModel(GenresRepository genresRepository
        , ApplicationDbContext context)
    {
       _genresRepository = genresRepository;
        _context = context;
    }

    public IList<Genre> Genres { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Genres = await _genresRepository.GetAllAsync();
        foreach (var genres in Genres)
        {
            // Verifique se existem registros relacionados
            var relatedRecords = _context.Series.Where(m => m.GenreId == genres.Id).ToList();
            if (relatedRecords.Count > 0)
            {
                genres.CanDelete = false;
            }
            else
            {
                genres.CanDelete = true;
            }
        }
    }
}
