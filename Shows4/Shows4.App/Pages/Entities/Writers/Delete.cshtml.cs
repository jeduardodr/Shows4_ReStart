namespace Shows4.App.Pages.Entities.Writers;
[Authorize]
public class DeleteModel : PageModel
{
    private readonly WriterRepository _writerRepository;

    public DeleteModel(WriterRepository writerRepository)
    {
        _writerRepository = writerRepository;
    }

    [BindProperty]
    public Writer Writer { get; set; }
    public IList<Writer> LWriter { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        Writer = await _writerRepository.FindWriterById(id);
        var (writer, writers) = await _writerRepository.GetWriterAndListAsync(id);
        if (Writer == null)
        {
            return NotFound();
        }
        LWriter = writers; // Devolve o Pais que vai bucar pelo ID
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        Writer = await _writerRepository.FindWriterById(id);

        if (Writer == null)
        {
            return NotFound();
        }

        await _writerRepository.RemoveWriter(Writer);

        return RedirectToPage("./Index");
    }
}