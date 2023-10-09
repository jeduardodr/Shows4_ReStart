namespace Shows4.App.Pages.Entities.Writers;
[Authorize(Roles = "Admin")]

public class CreateModel : PageModel
{
    private readonly WriterRepository _writerRepository;

    public CreateModel(WriterRepository writerRepository)
    {
        _writerRepository = writerRepository;
    }

    [BindProperty]
    public Writer Writer { get; set; }
    public IActionResult OnGet()
    {
        ViewData["CountryId"] = _writerRepository.GetCountries();
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _writerRepository.AddWriterAsync(Writer);

        return RedirectToPage("./Index");
    }
}
