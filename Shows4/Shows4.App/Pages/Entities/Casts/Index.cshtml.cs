namespace Shows4.App.Pages.Entities.Casts;
[Authorize(Roles = "Admin")]

public class IndexModel : PageModel
{
    private readonly CastRepository _castRepository;

    public IndexModel(CastRepository castRepository)
    {
      _castRepository = castRepository; 
    }

    public IList<Cast> Cast { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Cast = await _castRepository.GetCastAsync();
    }
}
