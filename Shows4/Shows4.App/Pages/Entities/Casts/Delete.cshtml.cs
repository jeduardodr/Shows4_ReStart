namespace Shows4.App.Pages.Entities.Casts;
[Authorize]

public class DeleteModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public DeleteModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Casts == null)
        {
            return NotFound();
        }
        var cast = await _context.Casts.FindAsync(id);

        if (cast != null)
        {
            Cast = cast;
            _context.Casts.Remove(Cast);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
