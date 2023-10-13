namespace Shows4.App.Pages.Entities.Seasons;
[Authorize]
public class IndexModel : PageModel
{
    private readonly SeasonRepository _seasonRepository;
   

    public IndexModel(SeasonRepository seasonRepository )
    {
       
        _seasonRepository = seasonRepository;
    }
    //Recebe o Id de Serie
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public Serie Serie { get; set; }

    public IList<Season> Season { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Season = await _seasonRepository.GetSeasonsBySerieIdAsync(Id);
        Serie = await _seasonRepository.GetSerieByIdAsync(Id);
    }


}
