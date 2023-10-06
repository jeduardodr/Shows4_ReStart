﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shows4.App.Data;
using Shows4.App.Data.Entities;

namespace Shows4.App.Pages.Entities.Seasons
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
        ViewData["EpisodeId"] = new SelectList(_context.Episodes, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Season Season { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seasons.Add(Season);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
