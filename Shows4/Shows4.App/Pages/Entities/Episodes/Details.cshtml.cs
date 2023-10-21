namespace Shows4.App.Pages.Entities.Episodes;
[Authorize(Roles = "Admin")]
public class DetailsModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public DetailsModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

  public Episode Episode { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Episodes == null)
        {
            return NotFound();
        }

        var episode = await _context.Episodes.FirstOrDefaultAsync(m => m.Id == id);
        if (episode == null)
        {
            return NotFound();
        }
        else 
        {
            Episode = episode;
        }
        return Page();
    }
}
