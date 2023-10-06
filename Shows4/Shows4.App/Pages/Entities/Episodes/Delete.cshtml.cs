using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;
using Shows4.App.Data.Entities;

namespace Shows4.App.Pages.Entities.Episodes
{
    public class DeleteModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public DeleteModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Episode Episode { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }

            var episode = await _context.Episodes.FirstOrDefaultAsync(m => m.Id == id);

            if (episode == null)
            {
                return NotFound();
            }
            else 
            {
                Episode = episode;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }
            var episode = await _context.Episodes.FindAsync(id);

            if (episode != null)
            {
                Episode = episode;
                _context.Episodes.Remove(Episode);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
