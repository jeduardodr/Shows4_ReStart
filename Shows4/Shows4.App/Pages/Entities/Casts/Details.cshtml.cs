namespace Shows4.App.Pages.Entities.Casts;
[Authorize]

public class DetailsModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public DetailsModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

  public Cast Cast { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Casts == null)
        {
            return NotFound();
        }

        var cast = await _context.Casts.FirstOrDefaultAsync(m => m.Id == id);
        if (cast == null)
        {
            return NotFound();
        }
        else 
        {
            Cast = cast;
        }
        return Page();
    }
}
