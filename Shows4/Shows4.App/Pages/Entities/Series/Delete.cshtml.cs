namespace Shows4.App.Pages.Entities.Series;
[Authorize]

public class DeleteModel : PageModel
{
    private readonly SerieRepository _serieRepository;

    public DeleteModel(SerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    [BindProperty]
    public Serie Serie { get; set; }
    public IList<Serie> LSerie { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Serie = await _serieRepository.GetSerie(id);
        var (serie, series) = await _serieRepository.GetSerieAndListAsync(id);
        if (Serie == null)
        {
            return NotFound();
        }
        LSerie = series; // Devolve o Pais e Genre que vai bucar pelo ID
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        await _serieRepository.DeleteSerie(id);

        if (Serie == null)
        {
            return NotFound();
        }

        return RedirectToPage("./Index");
    }
}
