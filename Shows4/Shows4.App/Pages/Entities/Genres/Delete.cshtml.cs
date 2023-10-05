namespace Shows4.App.Pages.Entities.Genres;
[Authorize]

public class DeleteModel : PageModel
{
    private readonly GenresRepository _genresRepository;

    public DeleteModel(GenresRepository genresRepository)
    {
       _genresRepository = genresRepository;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null )
        {
            return NotFound();
        }
        await _genresRepository.DeleteByIdAsync(id.Value);

        return RedirectToPage("./Index");
    }
}
