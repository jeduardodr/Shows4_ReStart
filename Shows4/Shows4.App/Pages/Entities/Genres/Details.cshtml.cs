namespace Shows4.App.Pages.Entities.Genres;
[Authorize]

public class DetailsModel : PageModel
{
    private readonly GenresRepository _genresRepository;

    public DetailsModel(GenresRepository genreRepository)
    {
        _genresRepository = genreRepository;
    }

  public Genre Genre { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var genre = await _genresRepository.GetByIdAsync(id.Value);
        if (genre == null)
        {
            return NotFound();
        }
        else 
        {
            Genre = genre;
        }
        return Page();
    }
}
