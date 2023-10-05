namespace Shows4.App.Pages.Entities.Countries;

[Authorize]
public class IndexModel : PageModel
{
    private readonly CountryRepository _countryRepository;

    public IndexModel(CountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public IList<Country> Countries { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Countries = await _countryRepository.GetAllAsync();
    }
}
