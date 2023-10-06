using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shows4.App.Data;
using Shows4.App.Data.Entities;

namespace Shows4.App.Pages.Entities.Series
{
    public class CreateModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public CreateModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id");
        ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
        ViewData["SeasonId"] = new SelectList(_context.Seasons, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Serie Serie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Series.Add(Serie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
