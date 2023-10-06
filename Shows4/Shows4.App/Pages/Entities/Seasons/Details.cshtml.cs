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
    public class DetailsModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public DetailsModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Season Season { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons.FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }
            else 
            {
                Season = season;
            }
            return Page();
        }
    }
}
