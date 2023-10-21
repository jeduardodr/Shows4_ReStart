namespace Shows4.App.Pages.Entities.Seasons;
[Authorize(Roles = "Admin")]
//Nao Utilizo este codigo no projeto 
public class DetailsModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public DetailsModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

  public Season Season { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Seasons == null)
        {
            return NotFound();
        }

        var season = await _context.Seasons.FirstOrDefaultAsync(m => m.Id == id);
        if (season == null)
        {
            return NotFound();
        }
        else 
        {
            Season = season;
        }
        return Page();
    }
}
