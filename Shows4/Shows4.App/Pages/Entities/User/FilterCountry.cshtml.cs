namespace Shows4.App.Pages.User;
[Authorize]
public class SeasonModel : PageModel
{
    private readonly SeasonRepository _seasonRepository;
    private readonly ApplicationDbContext _context;

    public SeasonModel(SeasonRepository seasonRepository, ApplicationDbContext context)
    {

        _seasonRepository = seasonRepository;
        _context = context;
    }
    //Recebe o Id de Serie
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public Serie Serie { get; set; }

    public IList<Season> Season { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Season = await _seasonRepository.GetSeasonsBySerieIdAsync(Id);
        Serie = await _seasonRepository.GetSerieByIdAsync(Id);
       
    }
}
