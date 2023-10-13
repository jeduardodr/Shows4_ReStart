namespace Shows4.App.Pages.Entities.Series;
[Authorize]

public class DetailsModel : PageModel
{
    private readonly SerieRepository _serieRepository;

    public DetailsModel(SerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public Serie Serie { get; set; }
    public IList<Serie> LSerie { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var (serie, series) = await _serieRepository.GetSerieAndListAsync(id);

        if (serie == null)
        {
            return NotFound();
        }

        Serie = serie;
        LSerie = series;

        return Page();
    }
}
