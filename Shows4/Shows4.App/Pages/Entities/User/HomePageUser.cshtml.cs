namespace Shows4.App.Pages.Entities.User;

[Authorize]
public class SerieIndexModel : PageModel
{
    private readonly SerieRepository _serieRepository;
    private readonly ApplicationDbContext _context;
    private const int ItemsPerPage = 8;

    public SerieIndexModel(SerieRepository serieRepository, ApplicationDbContext context)
    {
        _serieRepository = serieRepository;
        _context = context;
    }

    public IList<Serie> Serie { get; set; } = default!;
    public IList<Serie> Series { get; set; } = default!;
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public string Filter { get; set; }
    public string Test { get; set; }

    public async Task OnGetAsync(int currentPage = 1)
    {
        CurrentPage = currentPage;

        var count = await _context.Series.CountAsync();
        TotalPages = (int)Math.Ceiling(count / (double)ItemsPerPage);

        Serie = await _serieRepository.GetSeriesWithIncludesUser()
            .Skip((CurrentPage - 1) * ItemsPerPage)
            .Take(ItemsPerPage)
            .ToListAsync();

        Series = (from series in _context.Series
                           // where country.Name.StartsWith("p")
                       select series).ToList();

    }
    public void OnPost()
    {

        var test = Test;

        Series = (from series in _context.Series
                  where series.Title.Contains(Filter)
                       select series).ToList();

      
    }
}
