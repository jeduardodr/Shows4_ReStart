using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;
using Shows4.App.Data.Entities;

namespace Shows4.App.Pages.Entities.Series
{
    public class DeleteModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public DeleteModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Serie Serie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var serie = await _context.Series.FirstOrDefaultAsync(m => m.Id == id);

            if (serie == null)
            {
                return NotFound();
            }
            else 
            {
                Serie = serie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }
            var serie = await _context.Series.FindAsync(id);

            if (serie != null)
            {
                Serie = serie;
                _context.Series.Remove(Serie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
