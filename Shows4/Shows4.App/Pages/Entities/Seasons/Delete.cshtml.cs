namespace Shows4.App.Pages.Entities.Seasons;
[Authorize(Roles = "Admin")]

public class DeleteModel : PageModel
{
    private readonly SeasonRepository _seasonRepository;

    public DeleteModel(SeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }

    [BindProperty]
    public Season Season { get; set; }
    [BindProperty(SupportsGet = true)]
    public int SerieId { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Season = await _seasonRepository.GetSeason(id);

        if (Season == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        Season.SerieId = SerieId; // Armazene o SerieId antes de deletar
        await _seasonRepository.DeleteSeason(id);

        return RedirectToPage("./Index", new { id = Season.SerieId });
    }
}
