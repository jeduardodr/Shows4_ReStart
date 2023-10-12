namespace Shows4.App.Pages.Entities.Writers;
[Authorize]
public class DetailsModel : PageModel
{
    private readonly WriterRepository _writerRepository;

    public DetailsModel(WriterRepository writerRepository)
    {
        _writerRepository = writerRepository;
    }

    public Writer Writer { get; set; }
    public IList<Writer> LWriter { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var (writer, writers) = await _writerRepository.GetWriterAndListAsync(id);

        if (writer == null || writers == null)
        {
            return NotFound();
        }

        Writer = writer;
        LWriter = writers;

        return Page();
    }
}
