namespace Shows4.App.Pages.Entities.Genres;
[Authorize(Roles = "Admin")]

public class CreateModel : PageModel
{
    private readonly GenresRepository _genresRepository;

    public CreateModel (GenresRepository genresRepository)
    {
       _genresRepository = genresRepository;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Genre Genre { get; set; }
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
        {
            return Page();
        }
      await _genresRepository.AddGenreAsync(Genre);

        return RedirectToPage("./Index");
    }
}
