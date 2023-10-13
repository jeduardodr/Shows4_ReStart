using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shows4.App.Pages
{
    public class SeasonsModel : PageModel
    {
        private readonly SeasonRepository _seasonRepository;

        public SeasonsModel(SeasonRepository seasonRepository)
        {
           _seasonRepository = seasonRepository;
        }

        public IList<Season> Season { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Season = await _seasonRepository.GetSeasonAsync();
        }
    }
}
