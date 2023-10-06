namespace Shows4.App.Pages.Entities.Casts;
[Authorize]

public class EditModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public EditModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Cast Cast { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Casts == null)
        {
            return NotFound();
        }

        var cast =  await _context.Casts.FirstOrDefaultAsync(m => m.Id == id);
        if (cast == null)
        {
            return NotFound();
        }
        Cast = cast;
       ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id");
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

        _context.Attach(Cast).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CastExists(Cast.Id))
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

    private bool CastExists(int id)
    {
      return _context.Casts.Any(e => e.Id == id);
    }
}
