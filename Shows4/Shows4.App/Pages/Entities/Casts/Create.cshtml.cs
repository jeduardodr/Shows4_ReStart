namespace Shows4.App.Pages.Entities.Casts;
[Authorize]

public class CreateModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public CreateModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
    ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
        return Page();
    }

    [BindProperty]
    public Cast Cast { get; set; }
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Casts.Add(Cast);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
