using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;
using Shows4.App.Data.Entities;

namespace Shows4.App.Pages.Entities.Seasons
{
    public class IndexModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public IndexModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Season> Season { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Seasons != null)
            {
                Season = await _context.Seasons
                .Include(s => s.Episode).ToListAsync();
            }
        }
    }
}
