using System.Security.Claims;

namespace Shows4.App.Pages.Entities.Writers;
[Authorize]

public class IndexModel : PageModel
{
   // private readonly WriterRepository _writerRepository;
    private readonly Data.ApplicationDbContext _context;

    public IndexModel(Data.ApplicationDbContext context)
    {
        _context = context;
       // _writerRepository = writerRepository;
    }

    public IList<Writer> Writer { get;set; } = default!;

    public async Task OnGetAsync()
    {
       
       // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //var writerModel = await _writerRepository.GetWriteModelAsync(2);
        if (_context.Writers != null)
        {
            Writer = await _context.Writers
            .Include(w => w.Country).ToListAsync();
        }
    }
}
