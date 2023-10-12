using Shows4.App.Repositories;

namespace Shows4.App.Pages.Entities.Casts;
[Authorize]

public class CreateModel : PageModel
{
    private readonly CastRepository _castRepository;
    

    public CreateModel(CastRepository castRepository)
    {
       
        _castRepository = castRepository;
    }

    [BindProperty]  
    public Cast Cast { get; set; }

    public IActionResult OnGet()
    {
        ViewData["CountryId"] = _castRepository.GetCountries();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
        {
            ViewData["CountryId"] = _castRepository.GetCountries();
            return Page();
        }
      await _castRepository.AddCastAsync(Cast);
        return RedirectToPage("./Index");
    }
}
