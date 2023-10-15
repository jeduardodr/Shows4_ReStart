namespace Shows4.App.Pages.Entities.Episodes;
[Authorize]

public class EditModel : PageModel
{
    private readonly EpisodeRepository _episodeRepository;
    private readonly Shows4.App.Data.ApplicationDbContext _context;

    public EditModel(EpisodeRepository episodeRepository, ApplicationDbContext context)
    {
        _context = context;
        _episodeRepository = episodeRepository;
    }

    [BindProperty]
    public Episode Episode { get; set; } = default!;
    [BindProperty(SupportsGet = true)]
    public int SerieId { get; set; }
      

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var episode = await _episodeRepository.GetEpisodeAsync(id.Value);

        if (episode == null)
        {
            return NotFound();
        }
        Episode = episode;

        return Page();
    }
   
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Episode.SeasonId = SerieId; 
        await _episodeRepository.UpdateEpisodeAsync(Episode);

        return RedirectToPage("./Index", new { id = SerieId });
    }

}
