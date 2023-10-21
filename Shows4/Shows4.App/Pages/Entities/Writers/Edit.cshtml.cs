namespace Shows4.App.Pages.Entities.Writers;
[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly WriterRepository _writerRepository;
    
    public EditModel(WriterRepository writerRepository)
    {
        _writerRepository = writerRepository;
    }
    [BindProperty]
    public Writer Writer { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        Writer = await _writerRepository.GetWriterAsync(id.Value);
        if (Writer == null)
        {
            return NotFound();
        }
      
        ViewData["CountryId"] = _writerRepository.GetCountries();
        return Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["CountryId"] = _writerRepository.GetCountries();
            return Page();
        }
        try
        {
            await _writerRepository.UpdateWriterAsync(Writer);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_writerRepository.WriterExists(Writer.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToPage("./Index");
    }
 
}