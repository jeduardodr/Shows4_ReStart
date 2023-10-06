namespace Shows4.App.Pages.Entities.Writers;
[Authorize]
public class DeleteModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public DeleteModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.Writers == null)
        {
            return NotFound();
        }
        var writer = await _context.Writers.FindAsync(id);

        if (writer != null)
        {
            Writer = writer;
            _context.Writers.Remove(Writer);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
