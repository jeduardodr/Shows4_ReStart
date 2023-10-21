namespace Shows4.App.Pages.Entities.Seasons;
[Authorize(Roles = "Admin")]

public class EditModel : PageModel
{
    private readonly SeasonRepository _seasonRepository;
    

    public EditModel(SeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    [BindProperty]
    public Season Season { get; set; } = default!;
    [BindProperty(SupportsGet = true)]
    public int SerieId { get; set; }
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Season = await _seasonRepository.GetSeasonByIdAsync(id.Value);

        if (Season == null)
        {
            return NotFound();
        }

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

        // Defina o SerieId que vem do Index
        Season.SerieId = SerieId;

        try
        {
            await _seasonRepository.UpdateSeasonAsync(Season);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_seasonRepository.SeasonExists(Season.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index", new { id = Season.SerieId });
    }
}
