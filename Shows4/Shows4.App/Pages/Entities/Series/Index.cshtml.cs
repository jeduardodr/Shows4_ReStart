namespace Shows4.App.Pages.Entities.Series;
[Authorize]
public class IndexModel : PageModel
{
    private readonly SerieRepository _serieRepository;

    public IndexModel(SerieRepository serieRepository)
    {
        _serieRepository = serieRepository;
    }

    public IList<Serie> Serie { get; set; } = default!;

    public async Task OnGetAsync()
    {

        Serie = await _serieRepository.GetSeriesWithIncludes();
    }
}
