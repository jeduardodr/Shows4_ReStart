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
    public class DeleteModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public DeleteModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }
            var season = await _context.Seasons.FindAsync(id);

            if (season != null)
            {
                Season = season;
                _context.Seasons.Remove(Season);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
