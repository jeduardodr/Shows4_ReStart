namespace Shows4.App.Pages.Entities.Episodes;
[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly EpisodeRepository _episodeRepository;

    public CreateModel(EpisodeRepository episodeRepository)
    {
       _episodeRepository = episodeRepository;
    }
    //Para receber o Id da Season
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public IActionResult OnGet()
    {
        Episode = new Episode { SeasonId = Id };
        return Page();
    }

    [BindProperty]
    public Episode Episode { get; set; }


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
            Episode.SeasonId = id.Value;
        }
        else
        {
            return RedirectToPage("./Index", new { id = Episode.SeasonId });
        }
        await _episodeRepository.AddEpisodeAsync(Episode);

        return RedirectToPage("./Index", new { id = Episode.SeasonId });
    }
}
