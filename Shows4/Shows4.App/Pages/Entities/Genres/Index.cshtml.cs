namespace Shows4.App.Pages.Entities.Genres;
[Authorize]
public class IndexModel : PageModel
{
    private readonly GenresRepository _genresRepository;

    public IndexModel(GenresRepository genresRepository)
    {
       _genresRepository = genresRepository;
    }

    public IList<Genre> Genres { get;set; } = default!;

    public async Task OnGetAsync()
    {
            Genres = await _genresRepository.GetAllAsync();
    }
}
