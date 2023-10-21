namespace Shows4.App.Pages.Entities.Casts;
[Authorize(Roles = "Admin")]

public class EditModel : PageModel
{
    private readonly CastRepository _castRepository;
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public EditModel(CastRepository castRepository,Data.ApplicationDbContext context)
    {
        _context = context;
        _castRepository = castRepository;   
    }

    [BindProperty]
    public Cast Cast { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Cast = await _castRepository.GetCastAsync(id.Value);
        if (Cast == null)
        {
            return NotFound();
        }

        ViewData["CountryId"] = _castRepository.GetCountries();
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["CountryId"] = _castRepository.GetCountries();
            return Page();
        }
        try
        {
            await _castRepository.UpdateCastAsync(Cast);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_castRepository.CastExists(Cast.Id))
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
