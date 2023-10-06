namespace Shows4.App.Pages.Entities.Writers;
[Authorize]

public class EditModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public EditModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Writer Writer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Writers == null)
        {
            return NotFound();
        }

        var writer =  await _context.Writers.FirstOrDefaultAsync(m => m.Id == id);
        if (writer == null)
        {
            return NotFound();
        }
        Writer = writer;
       ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Writer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WriterExists(Writer.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool WriterExists(int id)
    {
      return _context.Writers.Any(e => e.Id == id);
    }
}
