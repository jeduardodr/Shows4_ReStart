namespace Shows4.App.Pages.Entities.Seasons;
[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly SeasonRepository _seasonRepository;
    private readonly ApplicationDbContext _context;


    public IndexModel(SeasonRepository seasonRepository, ApplicationDbContext context)
    {
       
        _seasonRepository = seasonRepository;
        _context = context;
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
        foreach (var season in Season)
        {
            // Verifique se existem registros relacionados
            var relatedRecords = _context.Seasons.Where(m => m.SerieId == season.Id).ToList();
            if (relatedRecords.Count > 0)
            {
                season.CanDelete = false;
            }
            else
            {
                season.CanDelete = true;
            }
        }
    }


}
