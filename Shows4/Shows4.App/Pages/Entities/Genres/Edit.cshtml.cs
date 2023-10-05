namespace Shows4.App.Pages.Entities.Genres;
[Authorize]

public class EditModel : PageModel
{
    private readonly GenresRepository _genresRepository;
    public EditModel(GenresRepository genresRepository)
    {
        _genresRepository   = genresRepository;
    }

    [BindProperty]
    public Genre Genre { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null )
        {
            return NotFound();
        }

        var genre =  await _genresRepository.GetByIdAsync(id.Value);
        if (genre == null)
        {
            return NotFound();
        }
        Genre = genre;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _genresRepository.UpdateAsync(Genre);
       

        return RedirectToPage("./Index");
    }

   
}
