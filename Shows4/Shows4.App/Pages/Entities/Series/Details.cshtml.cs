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
    public class DetailsModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public DetailsModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
