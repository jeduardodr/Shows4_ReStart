using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shows4.App.Data;
using Shows4.App.Data.Entities;

namespace Shows4.App.Pages.Entities.Seasons
{
    public class EditModel : PageModel
    {
        private readonly Shows4.App.Data.ApplicationDbContext _context;

        public EditModel(Shows4.App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Season Season { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Seasons == null)
            {
                return NotFound();
            }

            var season =  await _context.Seasons.FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }
            Season = season;
           ViewData["EpisodeId"] = new SelectList(_context.Episodes, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Season).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeasonExists(Season.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SeasonExists(int id)
        {
          return _context.Seasons.Any(e => e.Id == id);
        }
    }
}
