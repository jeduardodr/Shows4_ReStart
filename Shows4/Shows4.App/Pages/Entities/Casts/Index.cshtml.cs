namespace Shows4.App.Pages.Entities.Casts;
[Authorize]

public class IndexModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public IndexModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Cast> Cast { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Casts != null)
        {
            Cast = await _context.Casts
            .Include(c => c.Country).ToListAsync();
        }
    }
}
