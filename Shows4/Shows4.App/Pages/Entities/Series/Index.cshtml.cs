namespace Shows4.App.Pages.Entities.Series;

public class IndexModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public IndexModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Serie> Serie { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Series != null)
        {
            Serie = await _context.Series
            .Include(s => s.Country)
            .Include(s => s.Genre)
            .Include(s => s.Season).ToListAsync();
        }
    }
}
