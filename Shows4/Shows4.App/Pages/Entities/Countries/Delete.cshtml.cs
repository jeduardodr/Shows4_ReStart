namespace Shows4.App.Pages.Entities.Countries;
[Authorize(Roles = "Admin")]

public class DeleteModel : PageModel
{
    private readonly CountryRepository _countryRepository;

    public DeleteModel(CountryRepository countryRepository)
    {
       _countryRepository = countryRepository;
    }

    [BindProperty]
  public Country Country { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null )
        {
            return NotFound();
        }

        var country = await _countryRepository.GetByIdAsync(id.Value);

        if (country == null)
        {
            return NotFound();
        }
        else 
        {
            Country = country;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null )
        {
            return NotFound();
        }
        await _countryRepository.DeleteByIdAsync(id.Value);
        return RedirectToPage("./Index");
    }
}
