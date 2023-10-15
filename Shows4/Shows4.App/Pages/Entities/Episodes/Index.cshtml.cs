namespace Shows4.App.Pages.Entities.Episodes;
[Authorize]
public class IndexModel : PageModel
{
    private readonly EpisodeRepository _episodeRepository;
    

    public IndexModel(EpisodeRepository episodeRepository)
    {
       _episodeRepository   = episodeRepository;
    }
    //Recebe o Id de Serie
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public Season Season { get; set; }
    public IList<Episode> Episode { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Episode = await _episodeRepository.GetEpisodesAsync(Id);
        Season = await _episodeRepository.GetSeasonByIdAsync(Id);
    }
}
