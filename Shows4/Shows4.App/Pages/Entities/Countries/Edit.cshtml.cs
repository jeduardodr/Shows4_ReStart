namespace Shows4.App.Pages.Entities.Countries;
public class EditModel : PageModel
{
    private readonly CountryRepository _countryRepository;

    public EditModel(CountryRepository countryRepository)
    {
        _countryRepository  = countryRepository;
    }

    [BindProperty]
    public Country Country { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var country =  await _countryRepository.GetByIdAsync(id.Value);
        if (country == null)
        {
            return NotFound();
        }
        Country = country;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

       await _countryRepository.UpdateAsync(Country);

        return RedirectToPage("./Index");
    }

}
