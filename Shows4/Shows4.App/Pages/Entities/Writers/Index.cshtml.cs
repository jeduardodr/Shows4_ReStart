namespace Shows4.App.Pages.Entities.Writers;
[Authorize]

public class IndexModel : PageModel
{
    private readonly WriterRepository _writerRepository;

    public IndexModel(WriterRepository writerRepository)
    {
      _writerRepository = writerRepository;
    }

    public IList<Writer> Writer { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Writer = await _writerRepository.GetWritersAsync();
    }
}
