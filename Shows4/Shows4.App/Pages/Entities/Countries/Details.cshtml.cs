namespace Shows4.App.Pages.Entities.Countries;
[Authorize]

public class DetailsModel : PageModel
{
    private readonly CountryRepository _countryRepository;

    public DetailsModel(CountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

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
}
