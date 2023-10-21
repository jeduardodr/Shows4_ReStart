namespace Shows4.App.Pages.Entities.Series;
[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly SerieRepository _serieRepository;

    public CreateModel(SerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public IActionResult OnGet()
    {
        ViewData["CountryId"] = _serieRepository.GetCountries();
        ViewData["GenreId"] = _serieRepository.GetGenres();
        return Page();
    }

    [BindProperty]
    public Serie Serie { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["CountryId"] = _serieRepository.GetCountries();
            ViewData["GenreId"] = _serieRepository.GetGenres();
            return Page();
        }

        await _serieRepository.AddSerieAsync(Serie);

        return RedirectToPage("./Index");
    }
}
