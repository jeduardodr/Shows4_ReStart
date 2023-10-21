namespace Shows4.App.Pages.Entities.Series;
[Authorize(Roles = "Admin")]

public class EditModel : PageModel
{
    private readonly SerieRepository _serieRepository;

    public EditModel(SerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    [BindProperty]
    public Serie Serie { get; set; } = default!;
    

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var serie = await _serieRepository.GetSerieByIdAsync(id.Value);

        if (serie == null)
        {
            return NotFound();
        }

        Serie = serie;
        ViewData["CountryId"] = _serieRepository.GetCountries();
        ViewData["GenreId"] = _serieRepository.GetGenres();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["CountryId"] = _serieRepository.GetCountries();
            ViewData["GenreId"] = _serieRepository.GetGenres();
            return Page();
        }

        try
        {
            await _serieRepository.UpdateSerieAsync(Serie);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_serieRepository.SerieExists(Serie.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }
}
