namespace Shows4.App.Pages.Entities.Episodes;
[Authorize(Roles = "Admin")]
public class DeleteModel : PageModel
{
    private readonly EpisodeRepository _episodeRepository;
   

    public DeleteModel(EpisodeRepository episodeRepository)
    {
 
        _episodeRepository = episodeRepository;
    }

    [BindProperty]
  public Episode Episode { get; set; }
    [BindProperty(SupportsGet = true)]
    public int SeasonId { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Episode = await _episodeRepository.FindEpisodeAsync(id);

        if (Episode == null)
        {
            return NotFound();
        }
        SeasonId = Episode.SeasonId;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        Episode = await _episodeRepository.FindEpisodeAsync(id);

        if (Episode == null)
        {
            return NotFound();
        }

        await _episodeRepository.DeleteEpisodeAsync(Episode);

        return RedirectToPage("./Index", new { id = Episode.SeasonId });
    }
}
