namespace Shows4.App.Pages.Entities.Countries;
[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public CreateModel(Shows4.App.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Country Country { get; set; }
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Countries.Add(Country);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
