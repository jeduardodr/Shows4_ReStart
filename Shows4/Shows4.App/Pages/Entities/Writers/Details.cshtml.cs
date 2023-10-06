namespace Shows4.App.Pages.Entities.Writers;
[Authorize]

public class DetailsModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public DetailsModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

  public Writer Writer { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Writers == null)
        {
            return NotFound();
        }

        var writer = await _context.Writers.FirstOrDefaultAsync(m => m.Id == id);
        if (writer == null)
        {
            return NotFound();
        }
        else 
        {
            Writer = writer;
        }
        return Page();
    }
}
