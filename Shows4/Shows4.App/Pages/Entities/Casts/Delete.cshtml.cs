namespace Shows4.App.Pages.Entities.Casts;
[Authorize(Roles = "Admin")]

public class DeleteModel : PageModel
{
    private readonly CastRepository _castRepository;
    

    public DeleteModel(CastRepository castRepository)
    {

        _castRepository = castRepository;
    }

    [BindProperty]
  public Cast Cast { get; set; }
    public IList<Cast> LCast { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Cast = await _castRepository.FindCastById(id);
        var (cast, casts) = await _castRepository.GetCastAndListAsync(id);
        if (Cast == null)
        {
            return NotFound();
        }
        LCast = casts; // Devolve o Pais que vai bucar pelo ID
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        Cast = await _castRepository.FindCastById(id);

        if (Cast == null)
        {
            return NotFound();
        }

        await _castRepository.RemoveCast(Cast);

        return RedirectToPage("./Index");
    }
}
