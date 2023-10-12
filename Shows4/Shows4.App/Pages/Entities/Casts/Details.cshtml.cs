namespace Shows4.App.Pages.Entities.Casts;
[Authorize]

public class DetailsModel : PageModel
{
    private readonly CastRepository _castRepository; 

    public DetailsModel(CastRepository castRepository)
    {
        _castRepository = castRepository;
    }

  public Cast Cast { get; set; }
   public IList<Cast> LCast { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var (cast, casts) = await _castRepository.GetCastAndListAsync(id);

        if (cast == null || casts == null)
        {
            return NotFound();
        }
        Cast = cast;
        LCast = casts;
        return Page();
    }
}
