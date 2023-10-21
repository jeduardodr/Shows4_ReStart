namespace Shows4.App.Pages.Entities.Seasons;
[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly SeasonRepository _seasonRepository;

    public CreateModel(SeasonRepository seasonRepository)
    {
        _seasonRepository = seasonRepository;
    }
    //Para receber o Id da Serie
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public IActionResult OnGet()
    {
        Season = new Season { SerieId = Id };
        return Page();
    }

    [BindProperty]
    public Season Season { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Defina o SerieId com base no Id passado como parâmetro
        if (id.HasValue)
        {
            Season.SerieId = id.Value;
        }
        else
        {
            return RedirectToPage("./Index", new { id = Season.SerieId });
        }

        await _seasonRepository.AddAsync(Season);
        //Volta ao Index a partir do Id da Serie
        return RedirectToPage("./Index", new { id = Season.SerieId });
    }
}


